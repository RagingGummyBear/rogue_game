# Rogue_game

Rogue_game е најобична rogue-like игра. Станува збор за човек којшто сака да
се тепа со сè што ке стигне. Целта во е играта е да се појачува човечето такшто
ке е доволно моќно да може да го победи и „Main boss”. Покрај сите
непријатели има и продавачи, на којшто ке можете да им ја продадете
непотребната опрема и да купите опрема. Опремата која можете да ја најдете во
ковчезите се менува на одредени нивоа од херојот.
###Контроли
**Движењето** може да се изврши на два начини, со двоен клик над, под, лево, или
десно од херојот и со помош на стрелките.

Може да се врши проверка на на одреден дел од мапата со десен клик.

**Отварањето** на ковчези и **собирањето** на храна се извршува со space(или со
двоен клик на херојот).

Користењето на храната и ставањето опремата се врши со десен клик во
“inventory”. Исто така може и да се извади опрема со десен клик на “equipment”
делот.

Се започнува битка со непријател со едноставно движење кон него. На ист
начин се врши напаѓањето.

Кај продавачто се продава и купува со десен клик на опремата што сакате да ја
купите или продадете. Со лев клик може да се селектира и да се провери цената
на продавање/купување.

Со numlock0 се користи храната во „inventory“ ( може да се користи и со десен
клик )

Со пртискање на „s“ се отвара диалогот за одбирање на особини. Немора да се
искористат сите на секое наредно ниво ( препорачливо е да ја позавате опремата
којашто сакате да ја користите, па полсе да ги искористите особините ).

*При започнување на „New game” во главното мени се започнува со нов херој но,
со одбирање на „New map“ во текот на играта се менува само мапата и
ковчезите ( препорачливо е да се користи после секој 10-15 левели).Сo “save
game” се зачувува само херојот.*

###Решение
Мапата што е прикажана е составена од 9x9 Блокови. Во секој блок може да има
непријател,ковчег и околина. Блоковите којшто се прикажани се дел од класата
„ Blockgrid “ којашто содржи 90x90 Блокови. Главното човече не е член на блок.
Сите непријатели наследуваат од класата „Character“, сите итеми од класата
„item“, сите околини од класата „environment“. За генерирање на
блокови,итеми,околини,ковчежи и итеми има класа наречена „fabrika“. Има и
класа наречена „combat“ служи за започнување на борба и размена на удари.

#####Мој коментар

Мана во играта е безкорисно :( но, intelligence има корист. Незнам дали беше
паметно да почнам со идеата дека ке ми треба посебна класа за секој
итем/непријател, со оглед на тоа дека подоцна се одлучив со класата „fabrika“ да
можам да генерирам поразлични итеми со користење на иста класа. Се одличив
за класа, како класата „combat“ за да се намали кодот што ке го поседува секој
“character” и херојот. Исто така со „combat“ се осеќам дека можам да
имплементирам и поразлични ефекти од итеми. Најлошо нешто што направив е
посебен panel за секој итем (ми ги лимитираше можностите за лесно
манипулирање со содржината во "inventory").
