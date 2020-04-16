SQL Anywhere 12.0.1 - Versionshinweise für Unix und Mac OS X

Copyright (c) 2014, iAnywhere Solutions, Inc.
All rights reserved. All unpublished rights reserved.


SQL Anywhere 12 installieren
----------------------------

1. Wechseln Sie zu dem erstellten Verzeichnis und starten Sie das 
   Installationsskript, indem Sie die folgenden Befehle eingeben:
        cd ga1201
        ./setup

   Eine vollständige Liste der verfügbaren Installationsoptionen erhalten 
   Sie, indem Sie den folgenden Befehl eingeben:
        ./setup -h

   Für Mac OS X wird ein Installationsprogramm mit grafischer 
   Benutzeroberfläche (in englischer Sprache) bereitgestellt. Doppelklicken 
   Sie im Finder auf "Install SQL Anywhere" (SQL Anywhere installieren).

2. Befolgen Sie die Anweisungen des Installationsprogramms.


Installationshinweise 
---------------------

o In dieser Version ist es nicht mehr möglich, die 32-Bit-Version des
  MobiLink-Servers auf einem 64-Bit-Betriebssystem zu installieren. 
  Auf UNIX-Plattformen mit 64-Bit, auf denen die 32-Bit-Version des
  MobiLink-Server normalerweise installierbar ist, erlaubt eine angepasste
  Option nur die Installation der MobiLink-Clientkomponenten. 

  Beim Upgrade von Version 12.0.0 werden die 32-Bit-Versionen der 
  MobiLink-Serverkomponenten zwar aktualisiert, aber mlsrv12 gibt eine 
  Fehlermeldung aus und startet nicht.

o Das Linux-Installationsprogramm ermöglicht die Erstellung von
  Anwendungsmenüoptionen für Linux.
  Auf einigen Linux-Distributionen müssen Sie sich möglicherweise ab-
  und wieder anmelden, bevor die Änderungen sichtbar sind.


Dokumentation
-------------

Die Dokumentation finden Sie auf DocCommentXchange unter der folgenden Adresse:
    http://dcx.sybase.com

DocCommentXchange ist eine Online-Community, über die Sie die 
SQL Anywhere-Dokumentation aufrufen und Feedback und Kommentare 
bereitstellen können. DocCommentXchange ist das Standarddokumentationsformat 
für SQL Anywhere 12.

von folgender Seite herunterladen und installieren:
    http://www.sybase.com/detail?id=1069195 

Japanische Kunden finden die japanische Dokumentation auf der folgenden Seite:
    http://www.ianywhere.jp/developers/product_manuals/sqlanywhere/index.html


SQL Anywhere-Forum
--------------------

Das SQL Anywhere-Forum ist eine Website zum Austausch von Fragen und Antworten 
über die SQL Anywhere-Software sowie zum Kommentieren von Abstimmen über die Fragen 
und Antworten anderer Benutzer. Besuchen Sie das SQL Anywhere-Forum unter:
    http://sqlanywhere-forum.sybase.com.


Umgebungsvariablen für SQL Anywhere 12 festlegen
------------------------------------------------

Jeder Benutzer der Software muss die erforderlichen SQL Anywhere-
Umgebungsvariablen festlegen. Dies hängt vom jeweiligen 
Betriebssystem ab und wird in der Dokumentation unter "SQL Anywhere-Server  >
- Datenbankadministration >  Konfiguration Ihrer Datenbank > >
SQL Anywhere-Umgebungsvariablen" beschrieben.


Versionshinweise für SQL Anywhere 12
------------------------------------


SQL Anywhere-Server
-------------------

o SQL Anywhere-Server - Datenbanken aus SQL Anywhere Version 9 und älter
  müssen neu erstellt werden, bevor sie mit SQL Anywhere 12 verwendet werden
  können. Weitere Informationen zum Neuerstellen von Datenbanken in SQL
  Anywhere 12 finden Sie in der Dokumentation.

  Wenn Sie eine Datenbank für einen Mac OS X-Computer neu erstellen, müssen Sie
  einen der folgenden Schritte ausführen: 
  o Die Datenbank auf einer anderen Plattform neu erstellen.
  o Die Datenbank auf einem Computer einer anderen Plattform entladen und dann
    auf Mac OS X neu laden.
  o Die Datenbank auf Mac OS X mit einem Datenbankserver Version 9 entladen und
    die Datenbank dann mit Software-Version 12 neu laden.

o Falls Sie SQL Anywhere 9.0.1 (oder früher) als Serversoftware einsetzen,
  können sich SQL Anywhere 12 64-Bit-Clients möglicherweise nicht mit dem
  Datenbankserver über Shared Memory verbinden. Diese Einschränkung
  können Sie umgehen, indem Sie TCP/IP für die Verbindung benutzen oder den
  Server auf SQL Anywhere 9.0.2 oder SQL Anywhere 12 upgraden.

  Für HP-UX Itanium gelten weitere Einschränkungen: Clients oder Server von
  älteren Versionen als Version 9.0.2 Build 3207 (auch alle älteren Build-
  Nummern) können sich nicht mit Servern oder Clients von SQL Anywhere 12 mit 
  Shared Memory verbinden. Diese Einschränkung gilt auch, wenn sowohl Client 
  als auch Server beide 32-Bit-Versionen bzw. beide 64-Bit-Versionen sind. 
  Die Einschränkung können Sie umgehen, indem Sie TCP/IP verwenden oder die 
  ältere Software auf SQL Anywhere 9.0.2 Build 3207 (oder höher) bzw. 
  auf SQL Anywhere 12 aktualisieren.

o SQL Anywhere-Server - Auf RedHat 4 kann das Starten des Datenbankservers
  mit aktivierter GUI (grafischer Benutzeroberfläche) aufgrund eines glibc-Bugs
  zu einem Absturz führen. In Tests mit glibc 2.3.4-2.25 wurde festgestellt,
  dass das Problem mit diesem Patch behoben werden kann. Es wird daher
  empfohlen, glibc mit mindestens der obigen Patchversion zu verwenden.

o SQL Anywhere-Server - Auf Linux-Distributionen mit Kernels vor Version 2.6.13
  funktionieren lokale IPv6-Link-Scope-Adressen auf Grund eines bekannten
  Kernel-Bugs möglicherweise nicht einwandfrei. Wenn Sie lokale IPv6-Link-Scope-
  Adressen benutzen wollen, wird eine Aktualisierung des Kernels auf mindestens
  Version 2.6.13 empfohlen.

o SQL Anywhere-Server - Wenn sich der Computer auf Mac OS X im
  Ruhezustandsmodus befindet, wird die Netzwerkverbindung unterbrochen. Daher
  schlägt die Verbindung mit einem SQL Anywhere-Server fehl, der auf einem Mac
  läuft, welcher sich im Ruhezustandsmodus befindet. Dieses Problem können Sie
  umgehen, indem Sie den Ruhezustandsmodus auf ""Nie"" einstellen. Wählen Sie in
  den Systemeinstellungen die Option "Energie sparen". Auf der Registerkarte
  "Ruhezustand" verschieben Sie den Schieberegler auf "Nie".

o SQL Anywhere-Server - Auf AIX 5.3 wird empfohlen, dass Sie den letzten Patch
  Nummer IY79612 wegen eines Programmfehlers (Bugs) in syslogd installieren,
  der dazu führen konnte, dass der SQL Anywhere-Server nicht mehr reagiert.  

o SQL Anywhere-Server - Auf AIX wird Java/JRE 1.6 wegen eines
  VM-Programmfehlers nicht im Rahmen von ""Java in der Datenbank"" unterstützt.
  Ein entsprechener Fehlerbericht wurde an IBM gesendet.

o SQL Anywhere-Server - Auf Linux-Kernels höherer Versionen als 2.6.13 kann das
  Sichern auf oder Wiederherstellen von einem Bandlaufwerk fehlschlagen. Vor 
  Version 2.6.29.1, trat möglicherweise ein Fehler mit der Meldung "device or 
  resource busy" (Device oder Ressource ausgelastet) auf. Dieser Programmfehler
  wurde im Kernel behoben (siehe Kernel-Bug 12207). Nach Version 2.6.29.1
  kann weiterhin ein E/A-Fehler auftreten.

o SQL Anywhere-Server - Auf Solaris 10 auf AMD64-Architektur kann der 
  Datenbankserver beim Herunterfahren abstürzen. Dieses Problem können Sie 
  durch Installation der Solaris-Patches 118345 und 119964 beheben.

o SQL Anywhere Server, externe Perl-Umgebung - Wenn Sie auf Mac OS X Lion (10.7) 
  folgenden Befehl im Verzeichnis perlenv ausführen:

    perl Makefile.PL

  wird standardmäßig der Bitwert von Perl als 64-Bit festgelegt. Als Folge 
  davon, wird davon ausgegangen, dass es die Datei libdbextenv12_r.dylib in lib64 
  gibt. Dies ist nicht der Fall.

  Sie können dieses Problem umgehen, indem Sie vor Aufrufen von 
  Perl die folgende Variable setzen:

    $ export VERSIONER_PERL_PREFER_32_BIT=yes

  Alternativ können Sie auch den Standardwert auf Systemebene ändern:

    # defaults write com.apple.versioner.perl Prefer-32-Bit -bool yes


Administrationstools
--------------------

o Bei 64-Bit-Linux-Distributionen müssen Sie die
  32-Bit-Kompatibilitätsbibliotheken installieren, wenn Sie die
  Administrationstools verwenden wollen. Speziell die 
  32-Bit-X11-Bibliotheken sind erforderlich. Auf Ubuntu führen Sie 
  folgenden Befehl aus:


    Auf RedHat führen Sie folgenden Befehl aus: 
        yum install glibc.i686 

  If you do not install these libraries, the operating system cannot
  load the administration tools' binaries. When the load fails,
  you see an error like:

  -bash: /opt/sqlanywhere12/bin32/dbisql: No such file or directory


o In einigen asiatischen Sprachversionen kann es vorkommen, dass die
  Administrationstools die asiatischen Zeichen nicht richtig auf Linux anzeigen.

  Die Anzeigeprobleme werden hauptsächlich durch fehlende Schriften verursacht
  (Dateien mit dem Präfix "fontconfig" im Bibliotheksverzeichnis des JRE). In
  einigen Fällen können Sie die Schriftkonfigurationsdateien für das
  Betriebssystem und die Sprachkombination vom Betriebssystemhersteller
  erhalten. Lesen Sie den Abschnitt unten, der Ihrem Betriebssystem am ehesten
  entspricht. Falls keiner der Abschnitte zutrifft, versuchen Sie es mit den
  Schritten im Abschnitt WEITERE BETRIEBSSYSTEME.


  Red Flag 5 (Chinesisch)

  Stellen Sie sicher, dass Sie das folgende RPM-Paket für die Sprachumgebung
  Vereinfachtes Chinesisch installiert haben:
           ttfonts-zh_CN-5.0-2

  Andernfalls finden Sie die RPM-Pakete auf CD Nr. 2 der RedFlag 5-Distribution.

  Das RPM-Paket kann mit dem Befehl "rpm -i" installiert werden, wenn Sie als
  Root angemeldet sind.

  Führen Sie die folgenden Befehle aus, so dass die JRE die 
  Schriftkonfigurationsdatei für das System findet:

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.Linux.properties

  Als Alternative können Sie die Datei "zysong.ttf" in das
  JRE-Schriftenverzeichnis kopieren.

  Führen Sie die folgenden Befehle aus, so dass die JRE die Schriften findet:

  1. cd /usr/share/fonts/zh_CN/TrueType

  2. mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. cp zysong.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  Red Flag Linux Desktop 6

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Führen Sie die folgenden Befehle aus, so dass die JRE die Schriften findet:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/zh_CN/TrueType/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  RedHat Enterprise Linux 4

  Stellen Sie sicher, dass Sie die Schriften für die asiatischen
  Sprachumgebungen installiert haben. Andernfalls finden Sie die RPM-Pakete
  auf CD Nr. 4 der Redhat Enterprise Linux 4-Distribution.

  Die folgenden RPM-Pakete enthalten die Schriften für asiatische
  Sprachumgebungen:

           ttfonts-ja-1.2-36.noarch.rpm
           ttfonts-ko-1.0.11-32.2.noarch.rpm
           ttfonts-zh_CN-2.14-6.noarch.rpm
           ttfonts-zh_TW-2.11-28.noarch.rpm

  Jedes dieser RPM-Pakete kann mit dem Befehl "rpm -i" installiert werden, wenn
  Sie als Root angemeldet sind.

  Führen Sie die folgenden Befehle aus, so dass die JRE die
  Schriftkonfigurationsdatei für Ihr System findet:

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.RedHat.4.properties



  RedHat Enterprise Linux 5

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Stellen Sie sicher, dass die Schriften zur Anzeige der asiatischen
     Sprachen installiert sind. Zum Zeitpunkt des Verfassens dieser
     Informationen war eine Anleitung auf der folgenden Red Hat-Website
     verfügbar:

     www.redhat.com/docs/manuals/enterprise/RHEL-5-manual/en-US/Internationalization_Guide.pdf

  3. Die Administrationstools sollten dann in der Lage sein, die asiatischen
     Schriften anzuzeigen, ohne dass eine weitere Aktion notwendig ist.



  RedHat Enterprise Linux 6

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Stellen Sie sicher, dass die Sprachunterstützung und Schriften installiert sind, 
     die zum Anzeigen asiatischer Sprachen benötigt werden. 

  3. Führen Sie die folgenden Befehle aus, so dass die JRE die Schriften findet:

       ln -s /usr/share/fonts/cjkuni-ukai/ukai.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback/ukai.ttc



  SUSE 10

  Stellen Sie sicher, dass Sie die Schriften für die asiatischen
  Sprachumgebungen installiert haben. Andernfalls finden Sie die RPM-Pakete
  auf den CDs der SuSE 10-Distribution.

	  sazanami-fonts-20040629-7.noarch.rpm		    (CD #1)
	  unfonts-1.0.20040813-6.noarch.rpm		    (CD #2)
	  ttf-founder-simplified-0.20040419-6.noarch.rpm    (CD #1)
	  ttf-founder-traditional-0.20040419-6.noarch.rpm   (CD #1)

  Wenn diese Schriften nicht die gewünschten Zeichen enthalten, versuchen Sie
  es mit Schritten im Abschnitt WEITERE BETRIEBSSYSTEME.

  Jedes dieser RPM-Pakete kann mit dem Befehl "rpm -i" installiert werden, wenn
  Sie als Root angemeldet sind.

  Führen Sie die folgenden Befehle aus, so dass die JRE die Schriften findet:

  1. ln -s /usr/X11R6/lib/X11/fonts/truetype $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  Hinweis: Das Festlegen der Sprache in der Login-Eingabeaufforderung ist für
  JRE (und daher auch für die Administrationstools) nicht ausreichend, um die
  Sprachumgebung zu bestimmen. Vor dem Starten der Administrationstools sollte
  die Umgebungsvariable LANG auf einen der folgenden Werte festgelegt werden:

           ja_JP
           ko_KR
           zh_CN
           zh_TW

  Beispiel: In der Bourne-Shell und ihren Derivaten führen Sie folgenden
  Befehl aus, bevor Sie die Administrationstools starten:

        export LANG=ja_JP

  Einige deutsche Zeichen (z.B. Umlaut-A) werden in der Windows-Titelleiste
  nicht korrekt angezeigt, wenn die Sprachumgebung auf de_DE.UTF-8 gesetzt ist.
  Dieses Problem kann umgangen werden, indem die Sprachumgebung de_DE@euro
  verwendet wird.

  Eine vollständige Liste von gültigen Sprachumgebungseinstellungen finden 
  Sie in der Verzeichnisliste unter /usr/lib/locale.



  SUSE 11 Linux Enterprise Server

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Führen Sie Control Center aus, klicken Sie auf "Sprache", und wählen Sie
     beispielsweise "Japanisch" aus. Klicken Sie auf OK.

  3. Führen Sie die folgenden Befehle aus:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 8.10

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Führen Sie die folgenden Befehle aus:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/kochi/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 9.10

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Führen Sie die folgenden Befehle aus:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/vlgothic/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 10.04 und 11.04

  1. Fahren Sie alle aktiven grafischen Administrationstools (Sybase Central,
     Interactive SQL (dbisql), MobiLink-Monitor, SQL Anywhere-Monitor bzw.
     das SQL Anywhere-Konsolendienstprogramm (dbconsole) herunter.

  2. Führen Sie den folgenden Befehl aus:

	mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. Führen Sie einen oder mehrere der folgenden Befehle aus, um Schriften für die angegebene Sprache zu aktivieren:

     JAPANISCH:
	ln -s /usr/share/fonts/truetype/takao/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback


     VEREINFACHTES CHINESISCH:
	ln -s /usr/share/fonts/truetype/arphic/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback
	ln -s /usr/share/fonts/truetype/wqy/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback


  WEITERE BETRIEBSSYSTEME

  Wenn Sie über eine Distribution vom gleichen Typ, aber mit einer anderen
  Versionsnummer als in den obigen Abschnitten aufgeführt, verfügen, empfehlen
  wir, dass Sie die Schritte in dem am ehesten zutreffenden Abschnitt
  ausprobieren. Eventuell sollten Sie die  Schritte für die Version anpassen.
  Außerdem empfehlen wir, im Internet nach einer spezifischen Lösung für Ihre
  Distribution zu suchen. Falls mit keinem der Schritte eine zufriedenstellende
  Lösung zu erzielen ist, kann die nachfolgend beschriebene allgemeine Lösung
  angewandt werden.

  Im Folgenden wird eine Prozedur zur Installation einer Unicode
  TrueType-Schrift für die JRE erläutert, die von den Administrationstools
  verwendet wird. Diese Methode kann für alle nicht oben erwähnten
  Linux-Betriebssysteme angewandt werden. Andere TrueType-Schriften lassen
  sich auf ähnliche Weise installieren.

  1. Fahren Sie alle Administrationstools herunter, die ausgeführt werden.

  2. Laden Sie eine kostenlos erhältliche Unicode-Schrift, wie z. B. Bitstream
     Cyberbit, herunter. Diese Schrift finden Sie unter:

     ftp://ftp.netscape.com/pub/communicator/extras/fonts/windows/Cyberbit.ZIP

  3. Entzippen Sie Cyberbit.ZIP in ein temporäres Verzeichnis.

  4. Erstellen Sie das Verzeichnis $SQLANY12/sun/jre160_x86/lib/fonts/fallback.

  5. Kopieren Sie Cyberbit.ttf in das Verzeichnis
     $SQLANY12/sun/jre160_x86/lib/fonts/fallback.


MobiLink
--------

o Der MobiLink-Server benötigt einen ODBC-Treiber für die Kommunikation 
  mit der konsolidierten Datenbank. Die für die unterstützten konsolidierten 
  Datenbanken empfohlenen ODBC-Treiber finden Sie über den folgenden Link
  auf der Sybase-Startseite:
    http://www.sybase.com/detail?id=1011880

o Informationen zu den von MobiLink unterstützten Plattformen finden Sie unter:
    http://www.sybase.com/detail?id=1002288

o Bei UltraLite auf dem iPhone kann MobiLink in seltenen Fällen 
  folgenden Fehler melden:

    "Datenstromfehler: Nicht übereinstimmende Punkt-zu-Punkt-Chiffrierschlüssel"

  Dieser Fehler tritt beim Herstellen einer End-to-End-Chiffrierverbindung auf.
 Das Problem sollte im ersten EBF
  gelöst sein.


QAnywhere
---------

o Derzeit keine Einträge.


UltraLite
---------

o Derzeit keine Einträge.


Betriebssystemunterstützung
---------------------------

o Betriebssystemanforderungen für die Installation von SQL Anywhere 12 finden
  Sie unter http://www.ianywhere.com/products/supported_platforms.html. Auf
  dieser Webseite finden Sie außerdem Informationen über die jeweils zum
  Lieferumfang der unterstützten Plattform gehörenden SQL Anywhere-Komponenten.

o 64-Bit-Linux-Unterstützung - Manche 64-Bit-Linux-Betriebssysteme haben keine
  vorinstallierte Kompatibilitätsbibliotheken. Um die 32-Bit-Software zu
  verwenden, ist möglicherweise die Installation von 
  32-Bit-Kompatibilitätsbibliotheken für Ihre Linux-Distribution erforderlich. 
  Unter Ubuntu beispielsweise ist möglicherweise der folgende Befehl auszuführen:
	sudo apt-get install ia32-libs

  Auf RedHat führen Sie folgenden Befehl aus:
   yum install glibc.i686
    yum install libpk-gtk-module.so 
   yum install libcanberra-gtk2.i686 
    yum install gtk2-engines.i686    

o Linux-Unterstützung für dbsvc - Das Dienstprogramm dbsvc erfordert die 
  LSB init-Funktionen. Bei einigen Linux-Betriebssystemen sind diese nicht 
  standardmäßig installiert. Wenn Sie dbsvc verwenden wollen, müssen diese 
Funktionen für Ihre Linux-Distribution installiert werden.
  Führen Sie auf Fedora beispielsweise folgenden Befehl aus:
	yum install redhat-lsb redhat-lsb.i686

o SELinux-Unterstützung - Wenn Sie Probleme mit der Ausführung von SQL Anywhere 
  auf SELinux haben, stehen mehrere Lösungsmöglichkeiten zur Verfügung:

  o Markieren Sie die gemeinsam genutzten Bibliotheken um, so dass sie geladen
    werden können. Dies funktioniert auf Red Hat Enterprise Linux 5, hat aber
    den Nachteil, dass die SELinux-Features nicht verwendet werden.
     find $SQLANY12 -name "*.so" | xargs chcon -t textrel_shlib_t 2>/dev/null

  o Installieren Sie die mit SQL Anywhere 12 bereitgestellte Richtlinie. Im
    selinux-Verzeichnis der Installation befinden sich Quelldateien der
    Richtlinie. Anweisungen zum Erstellen und Installieren dieser Richtlinie
    finden Sie in der README-Datei in diesem Verzeichnis.

  o Schreiben Sie Ihre eigene Richtlinie. Sie können die mit SQL Anywhere 12
    bereitgestellte Richtlinie als Ausgangspunkt benutzen.

  o Deaktivieren Sie SELinux:
        /usr/sbin/setenforce 0

o Threads und Semaphore - Die Art der in der Software verwendeten Threads und
  Semaphore kann ziemlich wichtig sein, da es bei einigen Systemen zu
  Knappheit dieser Ressourcen kommen kann.

    o Unter Solaris verwendet SQL Anywhere POSIX-Threads und native Semaphore.

    o Unter Linux, AIX, HP-UX und Mac OS X verwendet SQL Anywhere pthreads
      (POSIX-Threads) und System V-Semaphore.

      Note: On platforms where System V semaphores are used, if the database
      server or a client application is terminated with SIGKILL, then System V
      semaphores are leaked. You must manually clean them up by using the
      ipcrm command.  In addition, client applications that terminate using
      the _exit() system call also leak System V semaphores unless the
      SQL Anywhere client libraries (such as ODBC and DBLib) are unloaded
      before this call.

o Verarbeitung von Alarmsignalen - Dies ist nur von Interesse, wenn Sie
  Non-Threaded-Anwendungen entwickeln und SIGALRM- oder SIGIO-Handler verwenden.

  SQL Anywhere verwendet SIGALRM- und einen SIGIO-Handler in Non-Threaded-
  Clients und startet einen sich wiederholenden Alarm (alle 200 ms). Korrektes
  Verhalten erhalten Sie, wenn SQL Anywhere diese Signale verarbeiten kann.

  Falls Sie einen SIGALRM- oder SIGIO-Handler definieren, bevor Sie eine oder mehrere
  der SQL Anywhere-Bibliotheken laden, wird SQL Anywhere sich an diese Handler 
  anhängen. Falls Sie einen Handler nach dem Laden von SQL Anywhere-Bibliotheken
  definieren, müssen Sie den Handler an SQL Anywhere anhängen. 

  Bei Verwendung des TCP/IP-Kommunikationsprotokolls benutzt SQL Anywhere
  SIGIO-Handler nur in Non-Threaded-Clients. Dieser Handler ist immer
  installiert, wird aber nur benutzt, wenn die Anwendung TCP/IP verwendet.

o Für RedHat 4 x86_64 empfohlene Patches - Beim Starten des 64-Bit-
  Datenbankservers mit aktivierter GUI (grafischer Benutzeroberfläche) kann es
  aufgrund eines glibc-Bugs zu einem Absturz des Datenbankservers kommen. 
  Dieses Problem können Sie beheben, indem Sie den neuesten glibc-Patch 
  von RedHat installieren.

o iAnywhere JDBC-Treiber auf HP Itanium - Wenn Sie den iAnywhere JDBC-Treiber
  auf HP Itanium einsetzen wollen, ist mindestens JRE Version 1.4.2 
  erforderlich. Alle älteren JRE-Versionen als 1.4.2 führen dazu, 
  dass die Anwendung beim Beenden nicht mehr reagiert.

o Kerberos-Unterstützung - Auf Solaris, HP-UX und IBM AIX werden
  Kerberos-Clients von MIT Kerberos 5 Version 1.4 unterstützt und getestet.
  Weitere entsprechend konfigurierte GSS-API Kerberos-Clients werden nicht
  getestet und nicht offiziell unterstützt.

o LDAP-Unterstützung - Auf HP-UX werden nur die von HP bereitgestellten LDAP-
  Bibliotheken, die im LDAP-UX Integration-Produkt ausgeliefert werden, getestet
  und unterstützt. Andere entsprechend konfigurierte LDAP-Bibliotheken
  funktionieren möglicherweise, werden aber nicht getestet und werden nicht
  offiziell unterstützt.

o Auf AIX und HP wurde ein Problem bei der Ausführung einer Java Virtual
  Machine im SQL Anywhere-Server festgestellt, wenn die Java VM eine andere
  Bitzahl als der Server verwendet. So funktioniert z.B. ein 64-Bit-Server
  nicht mit einer 32-Bit-Java VM. 

  Um dieses Problem zu umgehen, wurde ein Skript in ${SQLANY12}/java
  bereitgestellt, das zum Starten der Java VM verwendet wird. Das funktioniert
  nur, wenn JAVA_HOME richtig gesetzt ist. Standardmäßig geht das  Skript von
  der Verwendung einer 32-Bit-Java VM aus. Wenn Sie eine 64-Bit-Java VM
  verwenden möchten, ändern Sie den Wert von JAVA_BITNESS in sa_java.sh auf 64.

  Wenn Sie mehr als eine Java VM benutzen möchten, sollten Sie sa_java.sh
  kopieren und modifizieren, so dass es Ihre alternative Java VM lädt. Setzen
  Sie anschließend die Datenbankoption java_location so, dass sie auf das neue
  Skript verweist.

o Unter Red Hat Enterprise Linux werden einige Zeichen des privaten
  Nutzungsbereichs in Sybase Central, Interactive SQL (dbisql), dem
  MobiLink-Monitor, dem SQL Anywhere-Monitor oder dem SQL Anywhere-
  Konsolendienstprogramm (dbconsole) möglicherweise nicht richtig
  angezeigt.

  Für die Unicode-Codepoints "U+E844" und "U+E863" (als Zeichen für private
  Nutzung reserviert) werden in keiner der mit der Red Hat-Linux-Distribution
  ausgelieferten Truetype-Schriften Glyphen bereitgestellt. Die betreffenden
  Zeichen sind vereinfachte chinesische Schriftzeichen und in der
  Linux-Distribution Red Flag (chinesische Distribution) im Rahmen der Schrift
  zysong.ttf (DongWen-Song) verfügbar.

o Unter Red Hat Enterprise Linux kann es vorkommen, dass Sie keine Eingaben 
  in den Kennwortfeldern von Sybase Central, Interactive SQL, MobiLink-Monitor 
  oder dem SQL Anywhere-Konsolendienstprogramm (dbconsole) vornehmen können, wenn
  Ihr Computer für eine fernöstliche Sprache wie z.B. Chinesisch oder Japanisch
  konfiguriert ist und Sie KDE benutzen. Sie können dieses Problem umgehen,
  indem Sie den IME (Input Method Editor) deaktivieren.

  Klicken Sie auf das Red Hat-Menü und anschließend auf "Settings/Input Method"
  (Einstellungen/Eingabemethode). Das Dialogfeld "IM Chooser"
  (Eingabemethoden-Auswahl) wird angezeigt. Klicken Sie auf "Never use input
  methods" (Eingabemethoden nicht benutzen) und anschließend auf die
  Schaltfläche "Close" (Schließen). Melden Sie sich ab und dann wieder an.



PHP-Treiber
-----------

o php-5.1.x stürzt bei Verwendung des SQLAnywhere-Treibers möglicherweise ab.

  Wenn der SQLAnywhere PHP-Treiber mit dl() geladen wird und nicht richtig
  initialisiert werden kann, stürzt PHP möglicherweise ab, wenn das PHP-
  Skript Funktionen deklariert hat.

  Dieses Verhalten wird durch einen Bug in PHP 5.1.x verursacht. 
  Es gibt drei mögliche Problemlösungen: 

  1. Stellen Sie sicher, dass die SQLAnywhere-Umgebung richtig geladen ist und
     der SQLAnywhere PHP-Treiber die dbcapi-Bibliothek laden kann.

  2. Vermeiden Sie die Verwendung von dl() in Skripten und laden Sie das Modul,
     indem Sie einen Eintrag zur php.ini-Datei hinzufügen.

  3. Upgraden Sie auf php 5.2.x. Der Bug tritt in den php-5.2.x-Versionen
     nicht auf. 


SQL Anywhere-Monitor (nur Linux)
--------------------

o SQL Anywhere-Monitor reserviert beim Start 1 GB virtuellen
  Adressraum. Sie müssen sicherstellen, dass Sie zumindest diese
  Menge verfügbar haben. Um die Größe des verfügbaren virtuellen
  Adressraums anzuzeigen, führen Sie Folgendes aus:



Upgrade von SQL Anywhere-Monitor 11 auf SQL Anywhere-Monitor 12
---------------------------------------------------------------

Wenn Sie den SQL Anywhere-Monitor deinstallieren, werden sowohl die 
Anwendung als auch die Liste der Ressourcen und die gesammelten Metriken 
entfernt.

Wenn Sie ein Uprade der Ressourcen und Metriken des SQL Anywhere-Monitors von 
Version 11.0.1 auf Version 12 durchführen wollen, installieren Sie nicht
die ältere Version des SQL Anywhere-Monitors, bis Sie die folgenden Schritte
ausgeführt haben:

1) Erstellen einer Sicherungskopie der SQL Anywhere-Monitor-Datenbank.
2) Installieren einer neuen Version des Monitors.
3) Migrieren der Ressourcen und Metriken.

Detaillierte Informationen zur Migration der Daten und Einstellungen 
von 11.0.1 auf 12 finden Sie in der Dokumentation unter:

    SQL Anywhere 12 - Änderungen und Upgrades > Upgrade auf SQL Anywhere 12
    > Upgrade des SQL Anywhere-Monitors und Migration der Ressourcen
    und Metriken

