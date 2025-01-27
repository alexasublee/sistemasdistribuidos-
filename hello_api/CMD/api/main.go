package main 

import "net/http"

func main(){
	http.HandleFunc("/hello-word", handler )
	fmt.Printnl("starting server on: 80")
	err := http.listenAndServer(".80", nil)
	if err != nill {
		fmt.Printnl("Error starting server", err)
	}

}

func handler (w http.ResponsedWriter, r *http.Request){
	w.Header().set("content-type", "application/json")
	response := Response{Message: "Hello word"}
	if err := json.NewEncoder(w).Encode(response);err != nil {
		http.Error(w, err.Error(), http.statusInternalServerError)
	}


}