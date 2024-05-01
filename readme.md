

# Deploy CapRover

Para publicar a aplicação no CaRover é necessário os arquivos `captain-definition` e `Dockerfile`, ambos já configurados no projeto.

Bastar criar um arquivo `tar` com os arquivos do projeto e fazer o upload para o CapRover. (`tar -czf /tmp/deploy.tar.gz .`)

Em seguida configura a variável de ambiente `ConnectionStrings__Default` com a string de conexão para o banco de dados.