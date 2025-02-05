package peer

import (
	"bufio"
	"fmt"
	"net"
	"os"
)

var username string

func StartListening(port string, user string) {
	username = user
	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Error listening", err.Error())
		return
	}
	defer listener.Close()
	fmt.Printf("Peer is listening on port %v ...", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connections:", err.Error())
			continue
		}
		go handleConnection(conn)
	}
}

func ConnectToPeer(address string, user string) {
	username = user
	conn, err := net.Dial("tcp", address)
	if err != nil {
		fmt.Println("Error connecting to peer: ", err.Error())
		return
	}
	defer conn.Close()

	go handleConnection(conn)
	select {}
}

func handleConnection(conn net.Conn) {
	defer conn.Close()
	go receiveMessage(conn)
	sendMessage(conn)

}

func receiveMessage(conn net.Conn) {
	reader := bufio.NewReader(conn)
	for {
		message, err := reader.ReadString('\n')
		if err != nil {
			fmt.Println("Connection closed")
			return
		}
		fmt.Print(message)
	}

}

func sendMessage(conn net.Conn) {
	writer := bufio.NewWriter(conn)
	scanner := bufio.NewScanner(os.Stdin)
	for {
		fmt.Print("Enter message: ")
		if !scanner.Scan() {
			return
		}
		message := scanner.Text() + "\n"
		_, err := writer.WriteString(username + ": " + message)
		if err != nil {
			fmt.Println("Error sending message: ", err.Error())
			return
		}
		writer.Flush()
	}
}
