# A6PPR
Ticket System

## Before start TODO
Splň tady ty body a rozběháš projekt bez nejmenšího problému ;)

### GIT
Základním nástrojem, bez kterého se neobejdeš je GIT, je to verzovací nástroj, který nám umožní provádět změny na stejném projektu, bez toho abychom si křížili cestu v kódu.

#### Než začneš pracovat s gitem, otevři si v Bitbucketu svoje nastavení a přejdi do záložky SSH keys. Klíče jsou potřeba k ovšření tvého PC a připojení k serveru, a taky naopak. Klíč si musíš nejprve vygenerovat v PC a následně jeho hodnotu vložíš do Bucketu. Neboj, návod je přiložen v dané záložce a jsou to jen 3 příkazy :)

Need-To-Know na začátek:

#### [Branch] 	
		- tvoje větev, na které budeš provádět úpravý kódu
		- vždy kontroluj, že jsi na své větvi (označena tvým jménem)
		- změny do vyšší větve (developer, master) přenášej pouze pomocí žádostí (Pull / Merge request) na code reviewera (Adam, David), abychom předešli přenášení možných chyb a vyřazení aplikace z chodu
		- aplikace obsahuje větve Master (hlavní produknčí), Devel (větev do které budeme vnášet jednotlivé změny z našich větví a vyvíjet v ní aplikaci) , _NAME_ větve (jednotlivé větve vývojářů)
#### [Clone] 	
		- první příkaz který tě bude zajímat, a rovnou ten nejdůležitější!
		- jak už název vypovídá, jedná se o získání, reps. naklonování projektu ze serveru k tobě na lokální mašinu
		- klikni tedy na tlačítko clone v repozitáři, skopíruj si odkaz, naklonuj repo a hurá na vývoj. Nebo možná ne tak rychle a čti ještě chvlku dál...
#### [Commit] 	
		- commit je operace, při které řekneš, ano tyto soubory jsem upravoval, změny chci potvrdit, souhlasím s nimi a jdu vyvíjet dále
		- commituj co nejčastěji (změna hodnoty, barvy elementu, smazání souboru, přidání souboru)
		- čím více commitů uděláš, tím lépe se ti bude se změnami pracovat, věř mi, pokud commitneš 30 souborů a přestane ti najednou fungovat aplikace, horko těžko budeš hledat, ve kterém jsi udělal chybu
		- naopak pokud budeš mít časté commity, přehledně pojmenované, můžeš rychle dohledat svou chybu a opravit ji
		- vždy přehledně pojmenuj svůj commit, je jedno jestli cz/en/hu nebo jak se ti zlíbí, název je velice důležitý (přidán obrázek, upraven padding elementu..)
#### [Push] 	
		- Push je operace, při které pošleš veškeré svoje commity na Bitbucket. 
		- než uděláš push, jsou veškeré commity stornuté pouze lokálně, jakmile je nahraješ, můžeme si je díky cloudu a gitu stáhnout a přenést například tvoje změny do našich větví, či produkce
		- NIKDY nepushuj svou větev do cizích
#### [Pull / Fetch] 	
		- Fetch je operace, která se zeptá na nové změny na serveru
		- řekněme že přijdeš po víkendu, přepneš si na devel větev, protože předpokládáš, že kolegové pracovali a přes víkend do ní nahráli nějaké změny, samozřejmě chceš mít svůj kód sladěný a aktuální
		- fetch se dotáže na server a podá informace o všech změnách jak na dané větvi, tak i na větvích dalších
		- co teď ale? jak změny dostaneš k sobě? Jednoduše použijes příkaz Pull, ten dané změny pro aktuální větev stáhne		
#### [Merge / Rebase] 	
		- při pullu se může stát že bude nekonzistence tvých a souborů na webu, neměj však strach i o toto je git schopný se postarat
		- nabízí se dvě možnosti sloučení změn. První z nich je Merge, merge vezme soubor z webu a tvůj, porovná je a slouží rozdíly do nového souboru
		- provede toto porovnání u všech měněných souborů, výsledkem je poté commit označující všchny změny a jejich sloučení
		- Druhou možností je rebase, tato možnost nespojuje změny, vezme tvoji větev s commitnutými změnami a vloží ji jakoby na konec aktuální, chtěnné větve na serveru. Výsledkem je aktuální větev a teprve 		nad ní všechny tvoje změny
#### [Revert / Reset branch] 	
		- Pokud náhodou uděláš výše zmiňovanou chybu a ptřebuješ například resetovat změny v určitém souboru, pomůže ti Revert, ten vrátí veškeré změny v souboru zpět do předchozího stavu, nebo commitu
		- Pozor! revert funguje pouze na necommitnuté změny. Pokud se stane že uděláš celý commit špatný a bdeš ho potřebovat vrátit, můžeš to udělat pomocí resetu větvě na číslo chtěného commitu
#### To pro začátek ke Gitu stačí, nezapoměň si při instalaci nechat git přidat do PATH neboli cesty, aby tvé pomocné nástroje dokázaly git v PC najít

### Git GUI
Příkazový řádek není pro každého, dokonce ani pro mě, a proto je lepší si pomoci nástroji s grafickým rozhranním (GUI). Tyto nástroje ti přehledně zobrazí veškeré commity,větve, rozdíly v souborech a dokonce ti samy, nebo skoro samy zpracují změny při mergi a pullu. Nejlepší volbou pro tebe nejspíš bude Sourcetree, které je velice podobné na bitbucket, má jednoduché ovládání a na první pohled uvidíš veškeré příkazy, které jsem ti vypsal výše. DOkonce většina IDE (níže) integruje nástroje pro správu GITU, pokud tedy nejsi fanda GIT GUI, můžes svpje verzování provádět právě ze svého vývojového prostrředí.

### PHP (Xampp)
Poněvadž budeme pracovat s PHPkem, je nezbytně nutné si ho nainstalovat. Nejjednodušeji to uděláš pomocí XAMPPu. XAMPP je v podstatě balíček obsahující server, php samotné, fake email client, a nástroj pro připojení k FTP. [https://www.apachefriends.org/download.html] jen stáhni verzi pro tvůj systém a nech instalátor konat magic. Opět nezapoměň na PATH!!.

### Node
Node je na vysvětlení kapku složitější. Pro naše účely ti musí stačit, že je to nástroj, pomocí kterého můžes spravovat velké množství packagů, neboli balíčků, potřebných pro chod našeho projektu. Node je též schopný starat se o buildování CSS a scriptů, protože Laravel využívá preprocessory. Stáhni Node na této adrese a nech installer konat magic jako v předcházejícím kroku [https://nodejs.org/en/].

### Composer
Blížíme se ke konci, určitě už jsi žhavej a říkáš si kdy začne ten vývoj, jak na to, kdy už napíšu "Console.WriteLine("kokotské php")". Můžu tě ujistit, že je to za rohem. Předtím ale budeš potřebovat poslední nástroj a to je Composer. Composer je v podstatě dirigent, ředitel, nazvi to jak chceš. Stará se aby celý Laravel projekt pěkně šlapal, veškeré balíčky spolu ladily, vše plulo jak po másle. Tak neváhej a stahuj, postup už znáš [https://getcomposer.org/Composer-Setup.exe].

### IDE 
A jsme u idečka. Je v podstatě jedno v čem budeš psát kód, jestli poznámkový blok, Atom, Visual studio Code nebo cokoli jiné. Já osobně doporučuju PHPStorm od Jetbrains, jedná se o jeden z nejlepších nástrojů pro práci s PHP a webem jako takovým. Umožňuje ti ovládat Git přímo v sobě, také tě nahned spojí s databází a samozřejmě ti dodá grafický syntax. Ale říkám, volba je na tobě, stáhni si co ti bude vyhovovat, hlavně, že v tom budeš umět pracovat a bude ti to příjemné.


### Spuštění projektu
A jsme tady, pokud jsi to dočetl až sem, nejspíš máš vechny nástroje, naklonovaný projekt a čekáš co dál. Pár mini krůčků first.

## .env.example -> .env
V adresáři se nachází soubor .env.example. Jednoduše jej nakopíruj vedle sebe, ale ten nový přepiš pouze jen na .env. Je to konfigurační soubor celého projektu, bude obsahovat aplikační klíče, přístupy pro spojení k databázi a různě. Obsahuje i jednoduchý readmy, takže bys neměl ít problém ho nastavit, vlastně jen nakopírovat.

## composer install
Jako další zavolej našeho dirigenta, postará se o správné nastavení projektu hned po naklonování projektu. Ber to jakoby ti přišly kufry a on nyní vše vybalil a nachystal ti k použití. Celý Laravel projekt zabárá až stovky MB, a určitě by tě štvalo vše stahovat z gitu. Proto tento a následující nástroj stáhnou jen soubory označující co je potřeba a následně ti vše dostahují, doinstalují až na místě. Elegantní ne?

## npm install
A to samé udělá Node, jen pro další různé balíčky. 

## App key
Předposlední věc je nastavení aplikačního klíče, uděláš to pomocí příkazi "php artisan key:generate". Klíč se vygeneruje pro tvou danou aplikaci a uloží do tvého .env souboru. A nyní jsi ready to go!

## Serve 
Je to tu :) Last step. Stačí ti jen spustit aplikaci. Tak tam buchni "php artisan serve" a užij si tu šoouu.
(Může se ti stát že se to vyjebe a v prohlížeči na dané adrese nic neuvidíš a bude ti to hlásit chybu. V takovém případě první zkus "php -S localhost:8888 -t public". Pokud ani tento příkaz nepomůže, volej pomoc, boha, Šivu, nebo Dejva a Svozu)

# And thats it. Pokud ti naběhne stránka a vidíš nápis Laravelu, úspěšně jsi vše dokončil a můžeš začít vyvíjet. Pokud ne, obrať se na ostatní, kteří ti rádi pomůžou, dáme případně Teamspeak a vše nějak nastavíme. 

## A Pokud ti zbývá čas, projdi sizatím strukturu aplikace ať víš kde co hledat. Nezapoměň tay na dokumentaci na webu Laravelu která je velmi pěkně a přehledně napsaná.