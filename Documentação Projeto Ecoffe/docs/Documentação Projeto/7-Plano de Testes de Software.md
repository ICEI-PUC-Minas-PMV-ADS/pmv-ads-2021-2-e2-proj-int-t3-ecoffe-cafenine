# Plano de Testes de Software

Está seção detalha o planejamentos do processo de realização dos Testes de Software.

|Caso de Teste | CT-01 - Funcionamento do Administrador|
|:--|:--|
|**Requisitos Associados**|RF-001 - A aplicação deverá permitir o cadastro de produtos com suas informações necessárias pelo perfil do Administrador. <br/> RF-002 - A aplicação irá mostrar o gráfico com informações dos produtos com a interação dos usuários clientes.|
|**Objetivo do teste**| Verificar e testar o cadastro dos produtos e informações junto com o gráfico de interação dos clientes com os produtos já cadastrados. |
|**Passos**|1 - Acessar a aplicação com perfil Administrador. <br/>2 - Cadastrar os produtos e suas informações necessárias.<br/>3 - Com o perfil Administrador acessar a página de statisticas. <br/> 4 - Verificar o gráfico de interação de usuários com produtos(na primeira vez deverá estar zerada pois no teste o produto será primeiro cadastrado para após poder ser interagido pelos perfis Clientes).|
|**Critérios de Êxito**| Os produtos e suas informações devem ser cadastrados com sucesso e a aplicação deverá filtrar para que seja faito de forma correta de acordo com as regras de negócios e após o cadastro deverá aparecer na opção de Statisticas, mesmo que com o gráfico zerado(pois ainda não terá acesso dos clientes nos produtos recem cadastrados). |

|Caso de Teste | CT-02 - Funcionamento do Cliente com produtos |
|:--|:--|
|**Requisitos Associados**|RF-003 - A aplicação deverá ser acessada pelo usuário sem exigir login por obrigação. <br/> RF-004 - A aplicação deverá mostrar os produtos mais acessados(caso não possua produtos deverá ser informado / Caso nenhum produto tenha acessos ou compras deverá mostrar os produtos por ordem de inclusão na aplicação). <br/> RF-005 - O usuário cliente poderá acessar os produtos e ver suas informações. <br/> RF-006 - O usuário poderá adcionar os produtos desejados para compra no carrinho. |
|**Objetivo do teste**| Verificar se os produtos irão aparecer da forma desejada e se o cliente conseguirá adcionar de forma correta no carrinho. |
|**Passos**|1 - Acessar o navegador.<br/>2 - Informar o endereço do site.<br/>3 - Deverá aparecer a página inicial da aplicação.<br/>4 - Escolher e acessar um dos produtos acessados. <br/>5 - Clicar na opção para adcionar o carrinho. |
|**Critérios de Êxito**| O usuário Cliente deverá acessar a página inicial Tendo que aparecer os Produtos já cadastrados de acordo com as regras de negocios, poderá entrar nos produtos desejados obtendo acesso as suas informações e adcionar os produtos no carrinho. |

|Caso de Teste | CT-03 - Verificação da parte Carrinho |
|:--|:--|
|**Requisitos Associados**|RF-007 - Deverá acessar o menu Carrinho <br/> RF008 - Poderá verificar os produtos adcionado no cadastro<br/> RF009 - Poderá alterar a quantidade ou remover os produtos do carrinho.<br/> RF010 - Irá para a opção de Compra.
|**Objetivo do teste**|Verificar o funcionamento do Carrinho com os produtos escolhido e realizar as interações possíveis. |
|**Passos**| 1 - Acessar a aplicação<br/> 2 - Acessar o Menu Carrinho<br/> 3 - Verificar os produtos escolhidos<br/> 4 - Clicar na opção de adcionar, diminiur a quantidade ou remover os produtos de forma individual em cada produto ou na opção para todos os produtos do Carrinho. |
|**Critérios de Êxito**| Seção de fácil funcionalidade, verificando os produtos esolhidos e alterando as suas quantidades antes da confirmação da compra. |

|Caso de Teste | CT-04 - Realizar a confirmação de Compra |
|:--|:--|
|**Requisitos Associados**|RF-011 - A aplicação deverá realizar a Compra dos itens selecionados e confirmados na opção anterior do Carrinho.<br/> RF-012 Deverá confirmar a opção de Pagamento.<br/> RF-012 Deverá verificar o CEP e calcular o Frete.<br/> RF-013 Irá somar os valores e informar a confirmação com valores e forma de pagamento.<br/> RF-014 Irá realizar o pagamento e a compra.
|**Objetivo do teste**|Verificar a forma de pagamento escolhida por cliente e calcular o Frete através do CEP, somando os valores dos produtos com o Frete e confirmar o pagamento, realizando-o após a confirmação do cliente.|
|**Passos**|1 - Acessar o navegador.<br/>2 - Informar o endereço do site.<br/>3 - Acessar a opção de Menu Carrinho já com itens selecionados(Caso não haja itens no Carrinho, será necessário selecionar algum produto para que a opção Compra se torne acessível)<br/> 4 - Selecionar a opção Compra<br/> 5 - Escolher a opção de pagamento<br/> 6 - Colocar o CEP e clicar em calcular o Frete<br/> 7 - Confirmar os valores dos produtos mais o Frete, a forma de pagamento e realiar a Compra clicando na opção.|
|**Critérios de Êxito**|Realizar o pagamento e a compra dos produtos com a confirmação das informações sendo necessárias de acordo com a regra de négocios. |

|Caso de Teste | CT-05 - Buscar produtos desejados |
|:--|:--|
|**Requisitos Associados**|RF-015 - A aplicação deverá realizar a busca dos produtos<br/> RF-016 Poderá filtrar a Busca dos produtos por tags escolhidas pelo cliente.<br/>
|**Objetivo do teste**|Realizar a busca dos produtos por nome ou por tags escolhidas por cliente.|
|**Passos**|1 - Acessar o navegador.<br/>2 - Informar o endereço do site.<br/>3 - Escolher a opção de Busca em qualquer página da aplicação para usuários Clientes.<br/>4 - Digitar o nome do produto desejado ou selecionar a tag desejada.|
|**Critérios de Êxito**| Buscar os produtos pelo nome ou tag selecionada. |
