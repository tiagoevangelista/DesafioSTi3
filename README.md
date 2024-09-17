# Desafio STi3

Projeto iniciado em 24 e finalizado em 17 de setembro de 2024.

🎬 [Vídeo com demonstração e considerações sobre as escolhas e implementações](https://www.youtube.com/watch?v=GbnOcJtsxlc)  

<br>
  
## 🚩 Para rodar o projeto:

- Abra o *PMC (Package Manager Console)* e altere o *Default Projeto* para o *DesafioSTi3.INFRASTRUCTURE*
- Dê um *Update-Database*
- Rode o projeto API

<br>

## 💭 Considerações:

- A estutura segue (ou tenta se aproximar de) a **Clean Architecture**, mantendo as classes de **domínio** isoladas e, no caso de Pedido, com suas *regras de negócio* junto a ela.
- Na camada de Application, fiz a abstação das **interfaces** de repositórios e serviços, bem como dos **DTO** (embora saiba que hoje em dia usa-se muito o *record*, mas por estar mais habituado àqueles, dei preferência ao seu uso).
- Já na camada de **Infrasructure**, fiz a *implementação das interfaces*, bem como criei e configurei o **Contexto** da aplicação, aplicando regras de *mapeamento* das entidades para a criação no SQLServer.
- Por último, na camada de API
  -  eu fiz a **injeção das dependências** entre interfaces e suas implementações, todas com ciclo de vida Scoped;
  -  configurei o **Hangfire** (também abri uma rota para o dashboard dele);
  -  e criei os endpoints para adicionar e listar os *Clientes*, *Produtos* e *Pedidos*, sendo que neste último, após adicionado, é-se aplicada a regra e feito o envio para o **serviço externo de faturamento**;
