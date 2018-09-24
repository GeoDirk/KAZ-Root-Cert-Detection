# KAZ-Root-Cert-Detection
Русский текст ниже

Program to detect and remove the root level SSL certificates installed by NCALayer program

Compiled program can be found here: https://github.com/GeoDirk/KAZ-Root-Cert-Detection/releases/tag/v1.0.0.0



I was made aware recently of a newer program that you need to install in order accomplish just about anything with the Kazakh https://egov.kz government website (family, education, taxes, health care, etc.).  For example, if you go to that website, you are greeted with this message:

![eGov Website]( https://raw.githubusercontent.com/GeoDirk/KAZ-Root-Cert-Detection/master/kz_website_en.png )

If you follow through with installing their NCALayer program to gain website access, the program will install on your computer three of what are known as a root level SSL certificates.  These are powerful certificate that the issuer can use to create additional certificates that could be used to spoof other websites if you browse to them (e.g., Gmail, Yahoo, Facebook, Instagram, etc.).  If you were targeted by a hostile entity, these spoofed certificates based upon these three root certificates would be automatically approved as valid by your web browser.  Your browser would get the little green lock notification in the upper corner showing that you are connected with an encrypted connection.  However, in reality, you were being tricked into going to a bogus website because of the presence of those approved root certificate on your machine.  All your entered information (like username and password) instead would be going to the attacker.  This is obviously an undesirable situation to put yourself in.

It should be noted that at this time, there is NO evidence that this capability has been used this way.  But the point is, that it would be really difficult to know that your information has been intercepted. 

Perhaps you would think that uninstalling the NCALayer program would remedy the vulnerability - unfortunately and perhaps by design, uninstalling the program does not also uninstall those root level certificates.  They still are there on your machine available to be exploited.  Likewise, next time when you need to register your child for school, you would still need to reinstall the program.

So I've created a Windows tool that will allow you to have installed the NCALayer program along with those root level certificates and essentially toggle them on/off.  When you need to go do something on the government website, open up a "New Private Window" (Firefox) or "New incognito window" (Chrome) and run the NCALayer program.  That program will install the three root SSL certificates onto your machine to let everything work on their website.  Just be sure that you do not go to any other website (bank, social media) at this time where you could be spoofed; just complete your work on the government website.  Close down your browser completely and run my little program that you can find here: https://github.com/GeoDirk/KAZ-Root-Cert-Detection   (Full C# source code is available there if you are interested in how the program works)

KAZ-Root-Cert-Detection Program use - just run the program and it will iterate through all your root level certificates on your machine.  If it detects that the Kazakhstan ones are installed, it will flag them.  Just clicking the certificate removal button will cause the program to do several things:

- each of the three Kazakhstan root level certificates are removed from your machine; no more vulnerability
- the NCALayer program is removed from automatically starting each time you reboot your computer
- the NCALayer program is stopped in memory
- the NCALayer helper Window's tray icon is likewise stopped

What the program does not do by design is remove the NCALayer program completely off your machine.  It is "safe" as long as it is not running which my program prevents.  It also does allow you to keep the NCALayer program available for the next time you need it.  Just run the NCALayer program and it will reinstall those three certificates and the Window's tray icon.  Do your tasks on the government website in a private window, and once completed, run my program again to remove it all.  Simple.  Toggle it on/off

FAQ:

-         Use of the NCALayer program by itself doesn’t necessarily cause your computer to be able to be hacked

-         There is not a Mac version of this program.  If there is demand for it, I’ll consider making one

-         As stated before, there are no known incidences of this being exploited yet by an attacker.  But the opportunity to do so certainly exists with detection of an attack being very difficult.

-         Is this the same thing as the previously reported attempt late 2016 to have everyone in Kazakhstan install root certificates to access the internet which would allow the government access to all your login credentials?  No, that attempt created a lot of negative press globally.  But by forcing everyone who wants to do any simple task with the government to install and run this program is essentially the same thing.

If you have any questions, please feel free to open an issue.

-------------------------------------------------------------------------------

Дорогие друзья в Казахстане,

Недавно мне стало известно об относительно новой  программе, которую нужно установить для того, что совершить почти любые действия с казахстанским госсайтом https://egov.kz  (касательно семьи, образования, налогов, здравоохранения, и т.д.). Например, если вы зайдете на него, то вас приветствует данное сообщение:

![eGov Website]( https://raw.githubusercontent.com/GeoDirk/KAZ-Root-Cert-Detection/master/kz_website_ru.png )

Если вы установите программу NCALayer для дальнейшей работы на сайте, то она установит на ваш компьютер три так называемых SSL сертификата корневого уровня. Эти  сертификаты обладают такой мощью, что, тот, кто их выпустил может создать дополнительные сертификаты, которые могут использоваться для имитации других вебсайтов, если вы на них заходите (например, Gmail, Yahoo, Facebook, Instagram, и т.д.). В случае, если кто неблагоприятно нацелен на вас, то эти поддельные сертификаты, созданные на основе трёх корневых сертификатов будут автоматически одобрять ваш браузер как правомерный.  В нем появится маленький «зеленый замочек» в верхнем углу, уведомляющий о том, что ваше соединение защищено. Однако, в реальности, вас обманным путем заводят на фиктивный вебсайт благодаря присутствию тех одобренных корневых сертификатов на вашем компьютере. Вся введенная вами информация (как имя пользователя и пароль) будет передана перехватчику информации. Очевидно, что в такой ситуации оказаться нежелательно.

Следует подчеркнуть, что на данный момент НЕТ подтверждений того, что данный потенциал был использован в этом направлении. Но суть в том, что будет очень трудно узнать факт перехвата информация.

Может вы думаете, что удалив программу NCALayer вы  исправите своё уязвимое положение, но к сожалению, и возможно так было задуманно, что удаление программы не удаляет эти корневые сертификаты. Они все еще остаются на вашем компьютере, готовые к использованию.  Кроме того, в следующий раз, когда вам надо будет поставить ребенка в очередь в детский сад, надо будет установить программу снова.

Таким образом, я создал инструмент для  Windows, программу по выявлению казахстанских корневых сертификатов (KAZ-Root-Cert-Detection Program), которая позволит вам иметь программу NCALayer и сертификаты корневого уровня на вашем компьютере и по сути включить/выключить их. Когда вам надо зайти и получить услугу на гос сайте, откройте  "Новое приватное окно" (в Firefox) или "Новое окно в режиме инкогнито" (в Chrome) и установите/запустите программу NCALayer. Она установит три сертификата на ваш компьютер, для того, чтобы гос сайт работал. В это время не заходите ни на какие другие сайты  (банк, соц.сети), это то время, когда они могут быть клонированы. Сделайте все, что вам нужно было сделать на гос сайте. Полностью закройте ваш браузер и запустите созданную мною программу. Вы можете скачать её отсюда: https://github.com/GeoDirk/KAZ-Root-Cert-Detection   (Полный исходный код  C#  также там доступен, на тот случай, если вам интересно, как программа работает).

Как пользоваться программой по выявлению казахстанских корневых сертификатов (KAZ-Root-Cert-Detection Program)? Просто запустите программу и она пройдется по всем сертификатам корневого уровня на вашем компьютере.  Если она обнаружит установленные казахстанские сертификаты, она их выловит. При нажатии кнопки «Удалить казахстанские корневые сертификаты» программа сделает следующее:

- каждый из трех казахстанских сертификатов корневого уровня будет удален с вашего компьютера; опасности больше нет
- программа NCALayer не будет автоматически запускаться при запуске или перезагрузке  вашего компьютера
- программа NCALayer будет остановлена в памяти
- помощник программы NCALayer будет также остановлен в панели с иконками Windows

Программа по выявлению казахстанских корневых сертификатов (KAZ-Root-Cert-Detection Program) разработана так, что она не удаляет программу NCALayer полностью из вашего компьютера.  NCALayer не причинит вам вреда, потому что она не запущена и моя программа предовращает её запуск. Также моя программа позволяет хранить программу NCALayer до того, как она понадобится вам в следущий раз. Если она нужна, запустите её, она заново установит эти три сертификата и запустит их в системном лотке Windows. Всю работу на госсайте делаете в приватном окне и после завершения запустите мою программу снова для того, чтобы все удалить. Просто.  Включите и выключите.

ЧАВО:

-         Если вы используете программу NCALayer только с госсайтом, то это не обязательно приведет к возможности взлома компьютера.

-         Программа по выявлению казахстанских корневых сертификатов (KAZ-Root-Cert-Detection Program) не имеет версии для Mac компьютеров. Если будет спрос, я рассмотрю ее создание.

-         Как уже отмечалось выше, известных случаев того, что этим воспользовались нет. Но конечно возможность существует и распознать факт взлома сложно.

-         Имеет ли это отношение к ранее заявленной в 2016 году попытке необходимости установки корневого сертификата для интернет доступа в Казахстане, которая позволила бы получать властям все учетные данные? Нет, та попытка создала большой негативный отзыв повсеместно. Но принуждение любого устанавливать и использовать программу для того, чтобы просто получить гос услугу, полностью позволит сделать тоже самое.

Если у вас есть вопросы, пишите мне.
