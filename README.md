<p><font color="#004080" size="5" face="Segoe UI">&nbsp;</font><strong><font color="#000080" size="5" face="Trebuchet MS"><img border="0" src="../../Cursos/webmatrix/maco10.gif" width="233" height="32"></font></strong><span style="letter-spacing: 0.05em; font-weight:700"><font face="Segoe UI" size="4" color="#000080"> 
ASP 
.NET Core -&nbsp;Implementando a Onion Architecture - I</font></span></p>

<hr>

<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="98%">
  <tbody><tr>
    <td width="12%" align="center">
    <span style="letter-spacing: 0.05em; ">
    <font face="Trebuchet MS">
    <img border="0" src="../../maco_round1.png" width="93" height="92"></font></span></td>
    <td width="88%">
    <span style="letter-spacing: 0.05em"><font face="Segoe UI">Neste artigo 
	vamos criar uma aplicação <font color="#0000FF">ASP .NET Core WEBAPI</font>&nbsp; fazendo uma implementação básica da 
	arquitetura em Cebola ou <font color="#0000FF">Onion Architecture.</font></font></span></td>
  </tr>
</tbody></table>

<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Sei que você pode 
estar cansado de ver diagramas representando a <font color="#0000FF">Onion 
Architecture</font> mas como existem diversas possibilidades para representar as 
camadas e existem muitos diagramas eu vou mostrar o diagrama no qual eu vou 
basear o este artigo.</font></span></p>
<table border="0" width="97%">
	<tbody><tr>
		<td>
		<p align="left">
		<font face="Trebuchet MS">
		<a href="http://www.macoratti.net/curso_aspnet_core2.htm">
		<img border="1" src="../../ncursoaspncore2.jpg" width="446" height="58" class="responsive"></a></font><a href="http://www.macoratti.net/curso_webapi_core3.htm"><img border="1" src="../../curso_webapi1.jpg" width="449" height="59" class="responsive"></a></p></td>
	</tr>
</tbody></table>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Isso não significa 
que esta abordagem é mais correta que as demais. Significa apenas que é a minha 
abordagem.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Na
<font color="#0000FF">Onion Architecture</font> deve ser a <u>Camada de Domínio</u>
<i>(entidades e regras de validação comuns ao caso de negócios</i>) que está no 
núcleo de todo o aplicativo. Isso significa maior flexibilidade e menor 
acoplamento. Nesta abordagem, podemos ver que todas as camadas dependem apenas 
das camadas principais e o fluxo sempre deve ser no sentido das camadas externas 
para as camadas internas.</font></span></p>
<p>
<img border="0" src="aspc_implonion110.png" width="340" height="323" class="responsive"></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Nesta figura<font color="#0000FF"> 
Domain e Application</font> são camadas que estarão no centro do design. Podemos 
nos referir a essas camadas como <font color="#0000FF">Camadas Principais ou 
Core Layers</font>. Essas camadas não dependerão de nenhuma outra camada.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI"><b>Nota:</b>&nbsp;
<i>Outra maneira de ver a Arquitetura Cebola é como uma cebola que você pode 
descascar. Se você descascar a camada externa com a infraestrutura, apresentação 
e testes, então, a camada interna (núcleo do aplicativo) ainda deve funcionar. 
Assim, o núcleo do aplicativo deve ser capaz de funcionar sem infraestrutura e 
apresentação.<br>
</i>
<br>
A <font color="#0000FF">Camada de Domínio</font> geralmente contém <i>lógica corporativa e entidades</i>. A camada 
de aplicativo<i> teria interfaces e tipos</i>. A principal diferença é que a camada de 
domínio terá os tipos que são comuns a toda a aplicação, portanto, também pode 
ser compartilhada por outras soluções. Mas a camada de aplicativo<u> tem interfaces 
e tipos específicos de aplicativo. </u> <br>
<br>
Como as camadas principais nunca dependerão de nenhuma outra camada, como 
fazermos para acessar as camadas externas ?</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">A figura a seguir 
mostra o fluxo padrão de acesso às camadas. Sempre de fora para dentro.</font></span></p>
<p>
<img border="0" src="aspc_implonion1y.png" width="361" height="365" class="responsive"></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Para isso o que 
fazemos é criar interfaces na <font color="#0000FF">Camada Application</font> ou 
camada de Aplicativo e essas interfaces são implementadas nas camadas externas. 
Isso também é conhecido como <font color="#0000FF">DIP ou Princípio de Inversão 
de Dependência.</font><br>
<br>
Por exemplo, se seu aplicativo precisar enviar um e-mail, definimos uma 
interface <font color="#0000FF">IMailService</font> na camada de aplicativo e a 
implementamos fora das camadas principais. Usando o recurso da DIP, é possível 
alternar as implementações. Isso ajuda a construir aplicativos escaláveis.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">A<font color="#0000FF"> camada de 
infraestrutura</font> é onde você deseja adicionar sua infraestrutura, banco de 
dados, etc.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">A infraestrutura 
pode ser qualquer coisa. Talvez uma camada central do <i>Entity Framework</i> 
para acessar o banco de dados, ou uma camada feita especificamente para gerar <i>
tokens JWT</i> para autenticação ou mesmo uma camada <i>Hangfire</i>. Geralmente 
nesta camada definimos a lógica de acesso aos dados e as configurações do EF 
Core e suas migrações quando isso for pertinente.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Note que definimos 
uma camada para <font color="#0000FF">Testes</font> a serem realizados na aplicação.</font></span></p>
<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Nesta 
implementação eu não vou definir a camada de testes e nem vou usar o padrão CQRS. 
Vou fazer uma implementação básica inicial para mostrar o básico a ser feito 
para implementar a <font color="#800080">Onion Architecture.</font></font></span></p>
<p><span style="letter-spacing: 0.05em; font-weight: 700">
<font face="Segoe UI" color="#800080">Recursos usados:</font></span></p>
<ul>
	<li><span style="letter-spacing: 0.05em">
	<font face="Segoe UI" color="#800080">VS 2019 Community 16.9.1</font></span></li>
	<li><span style="letter-spacing: 0.05em">
	<font face="Segoe UI" color="#800080">EF Core</font></span></li>
	<li><span style="letter-spacing: 0.05em">
	<font face="Segoe UI" color="#800080">SQL Server</font></span></li>
</ul>
<p><span style="letter-spacing: 0.05em; font-weight: 700">
