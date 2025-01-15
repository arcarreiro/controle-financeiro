# Aplicação para o Processo Seletivo T2M

Este projeto foi desenvolvido por **Arthur Carreiro** como parte do processo seletivo da empresa **T2M**, após a conclusão da residência em TIC-Software do **Serratec**.

## 🛠️ Tecnologias Utilizadas

### Backend:
- **Linguagem:** C#
- **ORM:** Dapper
- **Autenticação:** JWT
- **Encriptação:** Bcrypt
- **Testes Unitários:** xUnit
- **Mocks para Testes:** MOQ

### Frontend:
- **Linguagem:** JavaScript
- **Framework:** React com Vite

### Bibliotecas Utilizadas:
- **react-datepicker** (Seleção de datas)
- **react-month-picker** (Seleção de meses)
- **react-bootstrap** (Componentes de UI)
- **react-icons** (Ícones)
- **react-toastify** (Notificações)
- **axios** (Requisições HTTP)
- **react-router-dom** (Gerenciamento de rotas)
- **date-fns** (Manipulação de datas)

---

## 🚀 Funcionalidades

- Autenticação de usuários utilizando JWT.
- Criptografia de senhas com Bcrypt.
- Manipulação de banco de dados utilizando Dapper.
- Testes unitários implementados com xUnit e simulações de objetos com MOQ.

---

## 🎯 Como Executar o Projeto

1. **Clonar o repositório:**
   ```bash
   git clone <url-do-repositorio>
   ```
2. **Instalar as dependências no Backend:**
   ```bash
   dotnet restore
   ```
3. **Rodar o Backend:**
   ```bash
   dotnet run
   ```
4. **Instalar as dependências no Frontend:**
   ```bash
   npm install
   ```
5. **Rodar o Frontend:**
   ```bash
   npm run dev
   ```
6. **Acessar a aplicação:**
   Abra o navegador e acesse `http://localhost:3000`


---

## 🗃️ Script do Banco de Dados

```sql
CREATE TABLE usuarios 
( 
 id SERIAL PRIMARY KEY,  
 nome VARCHAR(100) NOT NULL,  
 email VARCHAR(255) NOT NULL,  
 senha_hash VARCHAR(60) NOT NULL,  
 meta_financeira FLOAT,  
 UNIQUE (email),
); 

CREATE TABLE receitas
( 
 id SERIAL PRIMARY KEY,  
 descricao VARCHAR(255),  
 valor FLOAT NOT NULL,  
 data DATE NOT NULL,  
 id_usuario INT,  
 fonte VARCHAR(50)  
); 

CREATE TABLE despesas 
( 
 id SERIAL PRIMARY KEY,  
 descricao VARCHAR(255),  
 valor FLOAT NOT NULL,  
 data DATE NOT NULL,  
 id_usuario INT,  
 tipo VARCHAR(20)  
); 

ALTER TABLE receitas ADD FOREIGN KEY(id_usuario) REFERENCES usuarios (id);
ALTER TABLE despesas ADD FOREIGN KEY(id_usuario) REFERENCES usuarios (id);
```

---

## 📌 Contato
- **Autor:** Arthur Carreiro
- **LinkedIn:** [Arthur Carreiro](https://www.linkedin.com/in/arthurcarreiro/)

---

**Este projeto foi desenvolvido com dedicação e foco para o processo seletivo da T2M!** 🎯


