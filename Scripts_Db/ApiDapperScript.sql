	CREATE TABLE tb_produtora (
	id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	)

	CREATE TABLE tb_filme(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	ano INT,
	id_produtora INT FOREIGN KEY REFERENCES tb_produtora(id)
	)

		INSERT INTO tb_produtora(nome)
		VALUES ('WARNER BROS.'), ('Sony'), ('Marvel Studios'), ('Walt Disney Pictures')

		INSERT INTO tb_filme (nome, ano, id_produtora)
		VALUES ('Harry Potter e a pedra Filosofal', 2001, 1),
		('A Órfã', 2009, 1), ('Jogos mortais 3', 2002, 2), ('Viúva Negra', 2021, 3)

		SELECT * FROM tb_filme

		SELECT * FROM tb_produtora




		SELECT * FROM tb_produtora