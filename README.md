<p><span style="letter-spacing: 0.05em"><font face="Segoe UI">Na
<font color="#0000FF">Onion Architecture</font> deve ser a <u>Camada de Domínio</u>
<i>(entidades e regras de validação comuns ao caso de negócios</i>) que está no 
núcleo de todo o aplicativo. Isso significa maior flexibilidade e menor 
acoplamento. Nesta abordagem, podemos ver que todas as camadas dependem apenas 
das camadas principais e o fluxo sempre deve ser no sentido das camadas externas 
para as camadas internas.</font></span></p>
<p>
<img border="0" src="![image](https://user-images.githubusercontent.com/74432649/159140292-606ec486-f3a3-4fb1-9fc8-2e67e47dab90.png)" width="340" height="323" class="responsive"></p>
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
