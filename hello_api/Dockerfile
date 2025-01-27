FROM golang:1.23.4 as Build 

WORKDIR  /app
COPY go.mod ./
RUN go mod download 
RUN mkdir test 

COPY . . 

RUN CGO_ENABLED=0 GOOD=linux go build -o /api ./CMD/api 


EXPOSE  80

CMD ["/api"]