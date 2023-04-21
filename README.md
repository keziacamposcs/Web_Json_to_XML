# Web_Json_to_XML

 <img src="https://raw.githubusercontent.com/keziacamposcs/Web_Json_to_XML/main/README/Web_Json_to_XML.png?token=GHSAT0AAAAAACBC3FQA7LYXOXA7UMCBRLVCZCC7F4A" width="900">
 

Utilizando arquitetura **MVC** e **ASP.NET 6** para desenvolver uma aplicação que converte de uma API Json para XML podendo gerar o código e até baixar o XML :)

Foi utilizado a API do Banco Central do Brasil: [Link](https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/aplicacao#!/recursos/Moedas#eyJmb3JtdWxhcmlvIjp7IiRmb3JtYXQiOiJqc29uIiwiJHRvcCI6MTAwfSwicHJvcHJpZWRhZGVzIjpbMCwxLDJdLCJwZXNxdWlzYWRvIjp0cnVlLCJhY3RpdmVUYWIiOiJ0YWJsZSIsImdyaWRTdGF0ZSI6ewMwAzpbewNCAyIEMAQiLANBA30sewNCAyIEMQQiLANBA30sewNCAyIEMgQiLANBA31dLAMxAzp7fSwDMgM6W10sAzMDOnt9LAM0Azp7fSwDNQM6e319LCJwaXZvdE9wdGlvbnMiOnsDYQM6e30sA2IDOltdLANjAzo1MDAsA2QDOltdLANlAzpbXSwDZgM6W10sA2cDOiJrZXlfYV90b196IiwDaAM6ImtleV9hX3RvX3oiLANpAzp7fSwDagM6e30sA2sDOjg1LANsAzpmYWxzZSwDbQM6e30sA24DOnt9LANvAzoiQ29udGFnZW0iLANwAzoiVGFibGUifX0=)

 <img src="https://raw.githubusercontent.com/keziacamposcs/Web_Json_to_XML/main/README/page2.png?token=GHSAT0AAAAAACBC3FQBN7XQ7T2WTQG4ZA4AZCDADAQ" width="900">


Nos Controllers:

Ele tem três métodos que fazem solicitações HTTP GET para uma API do Banco Central do Brasil (BCB) que retorna informações sobre moedas. Os métodos são:

**GetXML():** Este método faz uma solicitação GET para a API do BCB e recebe uma resposta em formato JSON.
Em seguida, ele deserializa a resposta JSON em um objeto MoedasViewModel, usando o método JsonConvert.DeserializeObject(). Depois disso, ele serializa o objeto MoedasViewModel em um documento XML usando o método XmlSerializer.Serialize(). Por fim, ele retorna o documento XML como um arquivo com o nome "arquivo.xml".

**Get2XML():** Este método é semelhante ao método GetXML(), mas, em vez de retornar o documento XML como um arquivo, ele retorna o documento XML como uma string dentro de uma tag "< code > ".

**GetJson():** Este método faz uma solicitação GET para a API do BCB e retorna a resposta como uma string no formato JSON.

Cada método usa o namespace System.Net.Http para enviar solicitações HTTP e receber respostas HTTP.

Ele também usa os namespaces:
- System.Xml
- System.Xml.Serialization
- Microsoft.AspNetCore.Mvc
- Newtonsoft.Json
- RestSharp.Serializers 

para trabalhar com documentos XML e JSON.

O controlador faz parte do namespace Web_Json_to_XML.Controllers e tem uma dependência no modelo MoedasViewModel, que está no namespace Web_Json_to_XML.Models.
