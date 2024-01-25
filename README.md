
<h1>Apresentação do Repositório - Gerenciamento de Filmes com Dapper e SQL</h1>h1>
Bem-vindo ao Repositório de Gerenciamento de Filmes! Aqui, você encontrará uma API poderosa para cadastro, edição e exclusão de filmes. Este projeto utiliza o Dapper para comunicação eficiente com um banco de dados SQL, proporcionando uma solução robusta para o gerenciamento de sua coleção de filmes.

Objetivo
O objetivo principal deste repositório é oferecer uma solução simples e eficaz para o gerenciamento de informações sobre filmes. Seja para catalogar uma coleção pessoal ou integrar a funcionalidade de gerenciamento de filmes em um sistema mais amplo, esta API proporciona um conjunto de recursos flexíveis e eficientes.

Principais Recursos
1. Cadastro de Filmes
Utilize o endpoint POST /api/filmes para cadastrar novos filmes. Informe detalhes como título, diretor, ano de lançamento e gênero.

2. Edição de Filmes
Atualize as informações de qualquer filme utilizando o endpoint PUT /api/filmes/:id. A integração com o Dapper simplifica o processo de comunicação com o banco de dados SQL, garantindo eficiência nas operações de edição.

3. Exclusão de Filmes
Remova filmes do sistema de maneira eficaz usando o endpoint DELETE /api/filmes/:id. O Dapper facilita o processo de interação com o banco de dados, garantindo que as operações de exclusão sejam realizadas de forma segura e eficiente.

Tecnologias Utilizadas
Dapper: Um micro ORM (Object-Relational Mapper) que simplifica a interação com o banco de dados, proporcionando um desempenho otimizado e uma experiência de desenvolvimento eficiente.

SQL Server: O banco de dados SQL utilizado para armazenar e gerenciar as informações sobre os filmes.
