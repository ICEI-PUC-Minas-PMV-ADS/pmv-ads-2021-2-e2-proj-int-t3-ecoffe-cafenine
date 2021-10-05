# Especificações do Projeto

<p align= "justify">Os pontos mais relevantes a serem tratados neste projeto foram abordados e exemplificados através de personas fictícias e suas respectivas histórias, expondo casos comuns dos problemas levantados na pesquisa, que foram elaborados a partir do conhecimento comum e vivência dos membros da equipe.</p>

## Personas

|<h3>**Lucas**</h3> |  ||
| ------------------------------------------------------- | -------------------| ---------|
|<a href="https://unsplash.com/photos/g4DgCF90EM4"><img src=img/personas/lucas.png width="180" alt="Photo by Sung Wang on Unsplash"></a>| **Idade:** 28 | “Um sistema pensado para meu produto específico seria um tremendo diferencial.” |
**Motivação:**  Quer expandir seu  negócio de café para o mercado online.| **Frustrações:**  Só encontra sistemas genéricos, nada voltado para sua real necessidade. |  **História:** Lucas é microempreendedor e possui uma loja de café, e devido ao último ano, percebeu que investir no mercado online é fundamental.
| |  |  |
|<h3>**João**</h3> |  ||
| <a href="https://unsplash.com/photos/oMF2q4tlhDg"><img src=img/personas/joao.jpg width="180" alt='Photo by Portuguese Gravity on Unsplash'></a>| **Idade:** 69 | “Para um deficiente fisico, comprar um café gourmet sem ter o trabalho de me locomover até a loja seria incrivel.” |
**Motivação:** Comprar o melhor café da cidade através de uma plataforma online, onde não precisarei ir até a loja. | **Frustrações:**  É realmente problematico para João, que é deficiente físico, se locomover para comprar qualquer coisa. |  **História:** Por uma rara condição genética, João perdeu os movimentos das pernas ainda criança, e pela dificuldade de me locomover em sua cadeira de rodas é muito difícil realizar diversas tarefas.
| |  |  |
|<h3>**Regina**</h3> |  ||
| <a href="https://unsplash.com/photos/_H6wpor9mjs"><img src=img/personas/regina.jpg width="180" alt='Photo by Edward Cisneros on Unsplash'></a>| **Idade:** 43 | “A procura por novos produtos de qualidade para mim e para meus clientes.” |
**Motivação:** Comprar produtos variados relacionadas a café para testar em sua loja. | **Frustrações:** Dificilmente os fornecedores estão dispostos a venderem em baixa quantidade, para teste de aceitação entre os clientes, e nas lojas locais não se encontra a variadade que Regina deseja. |  **História:** Empresária, dona de cafeteria, precisa buscar produtos variados como copos, canudos, cafeteiras e o próprio café, para experimentar em sua loja junto com os clientes.
| |  |  |
|<h3>**Julio**</h3> |  ||
| <a href="https://unsplash.com/photos/KIPqvvTOC1s"><img src=img/personas/julio.jpg width="180" alt='Photo by Jonas Kakaroto on Unsplash'></a>| **Idade:** 37 | “Sou um amante de café, mas hoje em dia sempre encontro mais do mesmo.” |
**Motivação:** Comprar cafés finos e importados. | **Frustrações:**  Dificuldade de encontrar sites confiáveis onde pode comprar cafés de alta qualidade e importados. |  **História:** Julio sempre foi um amante de café. Mas ultimamente está trabalhando muito e não consegue mais ir nas lojas onde estava habituado. Julio já tem o costume de comprar outros itens online, mas não achou nenhum site confiável para comprar café.
| |  |  |
|<h3>**Sthepany**</h3> |  ||
| <a href="https://unsplash.com/photos/DrVJk1EaPSc"><img src=img/personas/sthepany.jpg width="180" alt='Photo by Isaiah McClean on Unsplash'></a>| **Idade:** 20 | “Conhecer novos sabores é minha paixão.” |
**Motivação:** Quer descobrir novos tipos de café para saborear. | **Frustrações:**  Não conhece lugares próximos onde poderia experimentar novos tipos de café, e tem dificuldades de usar o computador ou celular para comprar online. |  **História:** Sthepany tem vontade de experimentar cafés diferentes, mas onde mora há poucas opções de lojas especializadas. Além disso, ela sempre acha os sites de venda muito complicados e acaba desistindo.
| |  |  |

## Histórias de Usuários

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Lucas|Um site voltado para venda de cafés e relacionados.|Conectar-se mais facilmente com seu cliente.
|Lucas|Gerenciar produtos e vendas.|Organização do setor de vendas e ter controle sobre os produtos.
|Sthepany|Buscar os produtos de acordo com uma busca ou algum critério.|Facilitar o uso.
|Sthepany|Ordenar produtos exibidos de acordo com algum critério.|Faciltiar o uso.
|João|Colocar produtos em uma lista de desejos.|Comprar de forma recorrente sem precisar buscar o produto toda vez.
|Regina|Agrupar os produtos que serão comprados em um carrinho de compras.|Comprar vários produtos de uma vez.
|Lucas|Mostrar itens em destaque e recentemente vendidos|Aumentar a taxa de vendas.
|Lucas|Mostrar estatísticas sobre compras.|Dar insumos para melhores estratégias de negócio.
|Julio|Receber notificações sobre a entrega da minha compra.|Para haver preocupação ao esperar a entrega chegar.
|Regina|Avaliar os produtos comprados.|Para compartilhar minha opinião sobre um produto e ter opiniões prévias antes de comprar.
|Lucas|Permitir os clientes usarem cupons de desconto.|Oferecer promoções de forma limitada e/ou exclusiva.

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deverá vender produtos relacionados a café. | ALTA |
|RF-002| A aplicação deverá ter uma seção para o administrador, onde ele poderá gerenciar produtos e vendas. | ALTA |
|RF-003| A aplicação deverá permitir buscar os produtos por nome, tipo de produto, qualidade (café), especificidades do processo de produção (café), peso (café). | ALTA | 
|RF-004| A aplicação deverá permitir ordenar os produtos por preço, qualidade (café), peso (café). | ALTA |
|RF-005| A aplicação deverá permitir que os produtos sejam salvos em uma lista de desejos. | MÉDIA
|RF-006| A aplicação deverá permitir agrupar produtos em um carrinho de compras. | MÉDIA |
|RF-007| A aplicação deverá mostrar recomendações baseadas nas pesquisas do usuário. | BAIXA |
|RF-008| A aplicação deverá mostrar itens em destaque e recentemente vendidos. | BAIXA |
|RF-009| A aplicação deverá mostrar ao administrador estatísticas sobre os produtos mais procurados. | BAIXA |
|RF-010| A aplicação deverá notificar ao usuário sobre atualizações nas suas compras. | BAIXA |
|RF-011| A aplicação deverá permitir ao usuários avaliarem produtos comprados e comentar. | BAIXA |
|RF-012| A aplicação deverá permitir ao usuários usarem cupons de desconto. | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser compatível com os principais navegadores do mercado.| ALTA |
|RNF-002| A aplicação deve ser simples de usar. | ALTA |
|RNF-003| A aplicação deve ser responsiva em ambientes mobile. | MÉDIA |

## Restrições

<p align= "justify">As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir</p>

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| O projeto deverá ser feito com backend C#. |
|03| Só poderão ser utilizados programas gratuitos ou fornecidos pela PUC Minas |