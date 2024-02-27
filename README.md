Você está desenvolvendo uma aplicação que requer o processamento assíncrono de uma grande quantidade de dados. Além disso, a aplicação precisa ser capaz de executar várias tarefas em paralelo para otimizar o desempenho. 
 
Backend (C#):
1. Crie uma API RESTful em C# que simula o processamento dedadosassíncrono. A API deve conter umendpoint, com onomedasuaescolha,queaceite umalista de números inteiros como entrada.
2. Implemente um método assíncrono dentro da API que receba alistadenúmeros.
Para cada númeroexecutar o seguinte processamento de forma assíncrona: a. Criar um arquivo txt e gravar a tabuada no layout “n x tabNum = r” onde n é o número da lista que está sendoprocessado, tabNum é asequência de 1 a 10 e r é o resultado salvar o arquivo no diretório corrente com o nome “tabuada_de_n.txt” onde n é o número da lista que está sendo processado.

Nota:
Utilize a palavra-chave async e await para lidar com operações assíncronas;
Implemente um mecanismo de controle de concorrência para garantir que as operações sejam executadas de forma eficiente e segura em várias threads.

Frontend (Angular):
1. Crie uma interface de usuário (UI) simples em Angular que permita ao usuário inserir uma lista de números inteiros. Ao clicar em um botão, envie a lista de números para oendpoint criado anteriormente.
2. Exiba osresultados retornados pela API na interface de usuário em uma lista. 