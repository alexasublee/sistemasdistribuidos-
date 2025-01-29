// go run main.go (parametros fds fdsa)
// dotnet run ..
// py ei[]
package main

import (
	"os"

	peer "github.com/alexasublee/p2p/Internal/pear"
)

func main() {
	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}

}
