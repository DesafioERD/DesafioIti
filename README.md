# DesafioIti
# Repositório criado para a publicação do desafio Iti.
O link do desafio pode ser conferido aqui [https://github.com/itidigital/backend-challenge]

Considerações sobre o desafio:
* Por se tratar de validação de Hash (password), optei por não inserir logs na aplicação, pois considerei o processo de validação do hash (crítico e com dado sensível) um processo inicial para o armazenamento do mesmo. No caso de acompanhamento de outros fluxos ou processos, poderia realizar a implementação do Serilog, por exemplo.
* O desafio proposto informa o input e output, portanto, ainda levando em consideração a informação acima, inseri o contexto da validação em um método POST, imaginando que o mesmo possa ser utilizado para o armazenamento do hash criado pelo usuário.

Executando o código pela primeira vez:
* Faça o clone do repositório da maneira de sua preferência;
* Esta é uma aplicação aspnet core, logo, abra o projeto em sua IDE de preferência (Visual Studio, Visual Studio Code, Rider entre outras);
* Faça um build da solução e em seguida um restore dos pacotes do NuGet;
* Se tratando de uma aplicação aspnet core, as configurações de execução local a partir do IIS local está desabilitada, por favor, configure em sua IDE para que a mesma seja executada através do "console".
* Em sua primeira execução, para termos a confirmação de que a aplicação está com o comportamento esperado, a partir do navegador de sua preferência, acesse o endereço "http://localhost:5000/HealthCheck". A resposta deverá ser "I´m fine!" + data e hora atual.

Arquitetura e considerações da aplicação:
* Foram criadas as seguintes camadas (projetos), cada qual qual sua responsabilidade definida:
  * API: Ponto de entrada e saída das requisições. A mesma é responsável por receber as solicitações e realizar o retorno do processamento para quem (ou o que) a chamou. Esta camada também recebe a atribuição de realizar todas as validações pertinentes para a execução do fluxo. A validação foi aplicada com o Pacote "FluentValidation" do NuGet. Este pacote oferece recursos e ferramentas para que as validações estejam separadas por responsabilidades de domínios e no caso de uma validação de negócio, um método (ou métodos) específicos podem ser utilizados, sem que exista a separação de validação de campos (payload) ou validações de negócios. Ainda sobre a validação, a API só irá direcionar para processamento requisições devidamente validadas, assumindo assim um papel importante em sua atuação.
  * CORE: Este projeto irá concentrar todas as aplicações de negócio. Uma vez que a API já realizou todas as validações possíveis, o processamento é encaminhado para o CORE (se aplicável).
  * REPOSITORY: Nesta camada (projeto) a responsabilidade de acesso (comunicação) com banco de dados, cache ou outra tecnologia para armazenamento de dados. 
  * DOMAIN: Esta camada irá receber os domínios da aplicação, separados por responsabilidades,
  * Testes: Projeto destinado para testes unitários, tanto da camada de serviços como camada de API (Controllers).

Considerações para a validação do Hash:
* Utilizar método POST, informando no Body apenas uma string com o hash a ser validado.
* Se não alterado em API, utilizar porta 5000 para execução local.
* O método POST deverá ser direcionado para a "HashController"
* Em caso de validação positiva, será retornado código de retorno OK (200) com "true" como resposta.
* Em caso de validação negativa, será retornado código de retorno Bad Request (400) com "false" como resposta
* Em testes unitários, para os testes que contemplam o cenário de não validação, optei por validar cada cenário individualmente (char duplicado, não conter char minúsculo, entre outros). Foi criado um cenário de sucesso para a validação também.

Observação pessoal: Gostaria de agradecer a conversa, tempo dedicado e oportunidade para este desafio. Independentemente o resultado, tenho este desafio como criação de networking e para saber como estou sendo avaliado atualmente. Peço desculpas pelo tempo que levei para a entrega do desafio.
