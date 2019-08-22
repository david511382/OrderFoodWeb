protoc
go get -u github.com/golang/protobuf/protoc-gen-go
start protomodel.bat

go run main.go -ip
go build -tags release
./orderfood -ip

go test -v -count=1 ./src/database/mysql
go test -v -count=1 ./src/database/redis
go test -v -count=1 ./src/database/redis ./src/database/mysql

docker
docker-compose -f ./docker/docker-compose.yml up -d --build
https://philipzheng.gitbooks.io/docker_practice/content/dockerfile/instructions.html

go get github.com/akavel/rsrc
rsrc -manifest nac.manifest -o nac.syso

swag init

# EF
## Migrations
### 用 Class Library 使用 Migrations

套件
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
https://dotblogs.com.tw/abc12207/2018/03/24/entity-framework-core-migrations-at-separate-class-library-project

### 指令
Enable-migrations

Add-Migration InitialCreate -Context MemberContext
Update-Database -Context MemberContext
Remove-Migration -Context MemberContext

Add-Migration InitialCreate -Context MenuContext
Update-Database -Context MenuContext
Update-Database -Context MenuContext -Verbose
Remove-Migration -Context MenuContext