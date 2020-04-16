SQL Anywhere 12.0.1 Release Notes for Unix and Mac OS X

Copyright (c) 2014, iAnywhere Solutions, Inc.
All rights reserved. All unpublished rights reserved.


Installing SQL Anywhere 12
--------------------------

1. Change to the created directory and start the setup script by running
   the following commands:
        cd ga1201
        ./setup

   For a complete list of the available setup options, run the following
   command:
        ./setup -h

   For Mac OS X, a GUI setup program is provided. In the Finder, double-click
   "Install SQL Anywhere".
     
2. Follow the instructions in the setup program.


Installation notes
------------------

o We have removed the ability to install 32-bit MobiLink server on a 
  64-bit operating system.  On 64-bit UNIX platforms where 32-bit MobiLink 
  server would normally be installable, the option will change to include 
  the MobiLink client components only.

  For upgrades from version 12.0.0, the 32-bit MobiLink server components 
  will be upgraded to version 12.0.1, but mlsrv12 will give an error and 
  will not start up.

o The Linux installation can create Applications menu items on Linux.
  It may take a few minutes after the installation completes before the 
  changes appear in the Applications menu. On some Linux distributions,
  you need to log out and then log back in before the changes appear.
   
   
Documentation
-------------

The documentation is available on DocCommentXchange at:
    http://dcx.sybase.com
    
DocCommentXchange is an online community for accessing and discussing 
SQL Anywhere documentation on the web.  DocCommentXchange is the default 
documentation format for SQL Anywhere 12. 

If you prefer to use a local copy of the documentation, documentation can
be installed from:
    www.sybase.com/detail?id=1069195
    
For Japanese customers, documentation can be installed from:
    http://www.ianywhere.jp/developers/product_manuals/sqlanywhere/index.html


SQL Anywhere forum
------------------

The SQL Anywhere forum is a website where you can ask and answer questions
about the SQL Anywhere software, and comment and vote on the questions of
others and their answers. Visit the SQL Anywhere forum at:
    http://sqlanywhere-forum.sybase.com.
    
    
Setting environment variables for SQL Anywhere 12
-------------------------------------------------

Each user who uses the software must set the necessary SQL Anywhere environment
variables. These depend on your particular operating system, and are discussed
in the documentation in "SQL Anywhere Server - Database Administration > 
Configuring Your Database > SQL Anywhere environment variables".


Release notes for SQL Anywhere 12
---------------------------------


SQL Anywhere Server
-------------------

o SQL Anywhere Server - Databases from SQL Anywhere 9 and earlier must be
  rebuilt before they can be used with SQL Anywhere 12. After installing
  SQL Anywhere 12, consult the documentation for information about
  rebuilding databases.

  If you are rebuilding a database for a Mac OS X computer, you must do
  one of the following:
  o Rebuild the database on another platform.
  o Unload the database on a computer running a different platform, and then
     reload on Mac OS X.
  o Unload the database on Mac OS X using a version 9 database server, and
     then reload the database using the version 12 software.

o If you are using SQL Anywhere 9.0.1 or earlier server software,
  SQL Anywhere 12 64-bit clients may not be able to connect to the database
  server using shared memory. To work around this restriction, you can use 
  TCP/IP for communications, or upgrade the server to SQL Anywhere 9.0.2 or
  SQL Anywhere 12.

  For HP-UX Itanium, there are additional restrictions. Clients or servers from
  before version 9.0.2 build 3207 (including earlier versions) cannot communicate
  with servers or clients from SQL Anywhere 12 using shared memory. This 
  restriction applies even if both the client and server are 32-bit, or they 
  are both 64-bit. To work around this restriction, you can use TCP/IP, or 
  upgrade the older software to Adaptive Server Anywhere 9.0.2 build 3207 (or 
  later) or to SQL Anywhere 12.

o SQL Anywhere Server - On RedHat 4, starting the database server with the GUI
  enabled may crash it because of a glibc bug. Testing with glibc 2.3.4-2.25 
  showed that the problem was resolved. It is recommended that you run glibc 
  with at least this patch level.

o SQL Anywhere Server - On Linux distributions with kernels prior to 2.6.13,
  IPv6 link-scope local addresses may not work as expected due to a known 
  kernel bug. If you require the use of link-scope local IPv6 addresses it is 
  recommended that you update your kernel to at least version 2.6.13.
  
o SQL Anywhere Server - On Mac OS X, when the computer is in sleep mode, 
  network connectivity stops.  As a result, connecting to a SQL Anywhere server 
  running on a Mac that is in sleep mode fails. To avoid this problem, set
  the sleep mode to "Never". From System Preferences, select Energy Saver. On 
  the Sleep tab, move the slider to "Never".

o SQL Anywhere Server - On AIX 5.3, it is recommended that you apply at least
  patch number IY79612 because of a bug in syslogd that could cause SQL 
  Anywhere server to hang.  

o SQL Anywhere Server - On AIX, Java/JRE 1.6 is not supported for 
  Java-in-the-database support because of a VM bug. A bug report has been 
  submitted to IBM for this issue.

o SQL Anywhere Server - On Linux, kernel versions later than 2.6.13, 
  backing up to or restoring from a tape drive may fail. Prior to 
  2.6.29.1, a "device or resource busy" error may occur. This error has been 
  fixed in the kernel (see kernel bug 12207). After 2.6.29.1, you may 
  still encounter an I/O error.

o SQL Anywhere Server - On Solaris 10 on the AMD64 architecture, the database
  server may crash on shutdown. Applying Solaris patches 118345 and 119964 
  fixes this issue.
  
o SQL Anywhere Server, Perl external environment - On Mac OS X Lion (10.7), 
  running the following in the perlenv directory:
  
    perl Makefile.PL 
    
  by default will determine the bitness of perl as 64bit. This results in the
  expectation that there will be a libdbextenv12_r.dylib in lib64, which is
  not the case.
  
  To work around this, perl must be invoked with the following environment 
  variable set:
  
    $ export VERSIONER_PERL_PREFER_32_BIT=yes
  
  Alternatively you can change the default at the system level:
  
    # defaults write com.apple.versioner.perl Prefer-32-Bit -bool yes 

 
Administration Tools
--------------------

o On 64-bit Linux distributions, you must install the 32-bit compatibility 
  libraries if you want to use the administration tools. In particular, the
  32-bit X11 libraries are required. On Ubuntu, run:
	sudo apt-get install ia32-libs

  On RedHat, run:
	yum install glibc.i686
	
  If you do not install these libraries, the operating system cannot
  load the administration tools' binaries. When the load fails,
  you see an error like:
  
  -bash: /opt/sqlanywhere12/bin32/dbisql: No such file or directory
  

o In some Asian locales, the graphical administration tools may not always 
  display Asian characters properly by default.

  The display problems are primarily the results of missing font configuration 
  files (files with the prefix fontconfig in the JRE's lib directory). In some
  cases, you can obtain font configuration files for the operating system and
  language combination from the operating system vendor. Read the section
  below that corresponds most closely with your operating system. If none of
  the sections apply, try the steps in the section OTHER.


  Red Flag 5 (Chinese)

  Make sure you have installed the following RPM for the Simplified Chinese
  locale:
           ttfonts-zh_CN-5.0-2

  If not, the RPMs are available on CD #2 of the RedFlag 5 distribution.

  The RPM can be installed with the "rpm -i" command when you are logged in 
  as root.

  Run the following commands so that the JRE finds the font configuration
  file for your system:

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.Linux.properties
  
  Alternatively, you can copy the zysong.ttf file into the JRE's fonts 
  directory.
  
  Run the following commands so that the JRE finds the fonts:

  1. cd /usr/share/fonts/zh_CN/TrueType

  2. mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. cp zysong.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback


  
  Red Flag Linux Desktop 6

  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.

  2. Run the following commands so that the JRE finds the fonts:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/zh_CN/TrueType/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  RedHat Enterprise Linux 4

  Make sure you have installed fonts for the Asian locales. If not, the RPMs
  are available on CD #4 of the Redhat Enterprise Linux 4 distribution.

  The following RPMs contain the fonts for Asian locales:

           ttfonts-ja-1.2-36.noarch.rpm
           ttfonts-ko-1.0.11-32.2.noarch.rpm
           ttfonts-zh_CN-2.14-6.noarch.rpm
           ttfonts-zh_TW-2.11-28.noarch.rpm

  Each of these RPMs can be installed with the "rpm -i" command when you are
  logged in as root.

  Run the following commands so that the JRE finds the font
  configuration file for your system:

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.RedHat.4.properties



  RedHat Enterprise Linux 5
  
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.

  2. Ensure that the fonts required to display the Asian language are 
     installed. At the time of writing, a guide to installing fonts 
     was available from the Red Hat web site:

     www.redhat.com/docs/manuals/enterprise/RHEL-5-manual/en-US/Internationalization_Guide.pdf

  3. The administration tools should then be able to display the Asian
     fonts without futher action.



  RedHat Enterprise Linux 6
  
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.

  2. Ensure that the language support and fonts required to display the Asian
     language are installed.

  3. Run the following commands so that the JRE finds the fonts: 
  
       ln -s /usr/share/fonts/cjkuni-ukai/ukai.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback/ukai.ttc



  SUSE 10

  Make sure you have installed fonts for the Asian locales. If not, the RPMs
  are available on the SuSE 10 distribution CDs.

	  sazanami-fonts-20040629-7.noarch.rpm		    (CD #1)
	  unfonts-1.0.20040813-6.noarch.rpm		    (CD #2)
	  ttf-founder-simplified-0.20040419-6.noarch.rpm    (CD #1)
	  ttf-founder-traditional-0.20040419-6.noarch.rpm   (CD #1)

  If these fonts do not contain the characters you want to display, try the
  steps in the section OTHER.

  Each of these RPMs can be installed with the "rpm -i" command when you are
  logged in as root.

  Run the following commands so that the JRE finds the fonts:

  1. ln -s /usr/X11R6/lib/X11/fonts/truetype $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  Note: Setting the language at the Login prompt is not sufficient for the
  JRE (and hence the administration tools) to determine the locale. Before
  launching the administration tools, the environment variable LANG should be
  set to one of the following values:

           ja_JP
           ko_KR
           zh_CN
           zh_TW

  For example, in the Bourne shell and its derivatives, run the following
  command before launching the administration tools:

        export LANG=ja_JP

  Some German characters (for example, "a" with an umlaut) do not appear
  correctly in window title bars if the locale is set to de_DE.UTF-8.
  A workaround for this problem is to use the de_DE@euro locale.

  For a complete list of valid locale settings for this environment variable,
  see the directory listing of /usr/lib/locale.
  
  
  
  SUSE 11 Linux Enterprise Server
 
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.
     
  2. Run Control Center, and then click Language, and then select Japanese 
     (for example) in the list of languages. Click OK.
  
  3. Run the following commands:
     
     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback

     

  UBUNTU 8.10
  
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.
  
  2. Run the following commands:
 
     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/kochi/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback
  

  
  UBUNTU 9.10
  
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.
  
  2. Run the following commands:
 
     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/vlgothic/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback

 
  
  UBUNTU 10.04 and 11.04
  
  1. Shut down any graphical administration tools (Sybase Central, Interactive
     SQL (dbisql), the MobiLink Monitor, SQL Anywhere Monitor, or SQL Anywhere 
     Console utility (dbconsole) that are running.
  
  2. Run the following command:
	
	mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
	    
  3. Run one or more of the following commands to enable fonts for the indicated language:

     JAPANESE:
	ln -s /usr/share/fonts/truetype/takao/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback


     SIMPLIFIED CHINESE:
	ln -s /usr/share/fonts/truetype/arphic/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback
	ln -s /usr/share/fonts/truetype/wqy/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback


  OTHER

  If you have a distribution of the same type, but different version number
  than listed in the above sections, it is recommended that you try the steps
  from the closest corresponding section, adapting them as necessary to the
  different version number. You should also do an Internet search for a
  specific solution for your distribution. If none of these steps produces a
  satisfactory resolution, then the following general solution can be used.

  The following is a procedure for installing a Unicode, TrueType font into
  the JRE used by the administration tools. This method can be used for any
  Linux operating system not mentioned above. Other TrueType fonts can be
  installed in a similar manner.

  1. Shut down any administration tools that are running.

  2. Download a freely available Unicode font, such as Bitstream Cyberbit,
     which is available from

     ftp://ftp.netscape.com/pub/communicator/extras/fonts/windows/Cyberbit.ZIP

  3. Unzip Cyberbit.ZIP into a temporary directory.

  4. Create the directory $SQLANY12/sun/jre160_x86/lib/fonts/fallback.

  5. Copy Cyberbit.ttf into the $SQLANY12/sun/jre160_x86/lib/fonts/fallback 
     directory.
     

MobiLink
--------

o The MobiLink server requires an ODBC driver to communicate with the 
  consolidated databases. The recommended ODBC drivers for a supported 
  consolidated database can be found from the Sybase home page through the 
  following link:
    http://www.sybase.com/detail?id=1011880
    
o For information about the platforms supported by MobiLink, see:
    http://www.sybase.com/detail?id=1002288
  
o With UltraLite on the iPhone, MobiLink can randomly, though rarely, report
  the error:

    "Stream Error: Mismatched end-to-end encryption keys"
    
  when establishing an end-to-end encryption link. This issue should be 
  addressed in the first EBF.
  

QAnywhere
---------

o There are no items at this time.

 
UltraLite
---------

o There are no items at this time.


Operating system support
------------------------

o Operating system requirements for installing SQL Anywhere 12 can be found
  at http://www.ianywhere.com/products/supported_platforms.html. This web page
  also contains information about SQL Anywhere components included for each
  supported platform.

o 64-bit Linux support - some 64-bit Linux operating systems do not include
  preinstalled 32-bit compatability libraries. To use 32-bit software,
  you may need to install 32-bit compatability libraries for your Linux
  distribution. For example, on Ubuntu, you may need to run the following 
  command:
	sudo apt-get install ia32-libs
	
  On RedHat, run:
	yum install glibc.i686
	yum install libpk-gtk-module.so 
	yum install libcanberra-gtk2.i686 
	yum install gtk2-engines.i686

o Linux support for dbsvc - The dbsvc utility requires the LSB init-functions.
  Some Linux operating systems do not include these preinstalled by default.
  To use dbsvc, you need to install them for your Linux distribution. 
  For example, on Fedora, run the following command:
	yum install redhat-lsb redhat-lsb.i686 
	
o SELinux support - If you are having problems running SQL Anywhere on SELinux,
  you have several options:

  o Relabel the shared libraries so that they can be loaded. This solution 
    works on Red Hat Enterprise Linux 5, but has the drawback of not using the
    SELinux features.
	find $SQLANY12 -name "*.so" | xargs chcon -t textrel_shlib_t 2>/dev/null

  o Install the policy provided with SQL Anywhere 12. In the the selinux 
    directory of your installation there are policy sources. See the README 
    file in that directory for instructions on building and installing that 
    policy.

  o Write your own policy. You may want to use the policy provided with 
    SQL Anywhere 12 as a starting point.

  o Disable SELinux:
        /usr/sbin/setenforce 0
	
o Threads and semaphores - The type of threads and semaphores used in
  software can be quite important, as some systems can run out of these
  resources.

    o On Solaris, SQL Anywhere uses POSIX threads and native
      semaphores.

    o On Linux, AIX, HP-UX, and Mac OS X, SQL Anywhere uses
      pthreads (POSIX threads) and System V semaphores.
      
      Note: On platforms where System V semaphores are used, if the database
      server or a client application is terminated with SIGKILL, then System V 
      semaphores are leaked. You must manually clean them up by using the 
      ipcrm command.  In addition, client applications that terminate using
      the _exit() system call also leak System V semaphores unless the
      SQL Anywhere client libraries (such as ODBC and DBLib) are unloaded 
      before this call.

o Alarm handling - This is of interest only if you are developing
  non-threaded applications and use SIGALRM or SIGIO handlers.

  SQL Anywhere uses a SIGALRM and a SIGIO handler in non-threaded
  clients and starts up a repeating alarm (every 200ms). For correct behavior,
  SQL Anywhere must be allowed to handle these signals.

  If you define a SIGALRM or SIGIO handler before loading any SQL Anywhere
  libraries, then SQL Anywhere chains to these handlers.
  If you define a handler after loading any SQL Anywhere libraries,
  you need to chain from the SQL Anywhere handlers.

  If you use the TCP/IP communications protocol, SQL Anywhere uses
  SIGIO handlers in only non-threaded clients. This handler is always
  installed, but it is used only if your application makes use of TCP/IP.

o Patches recommended for RedHat 4 x86_64 - Starting the 64-bit database server
  with the GUI enabled may crash it because of a glibc bug. Applying the latest
  glibc patch from RedHat resolves this issue.

o iAnywhere JDBC driver on HP Itanium - If you plan to use the iAnywhere JDBC
  Driver on HP Itanium, the minimum JRE requirement is 1.4.2. Using anything 
  earlier than 1.4.2 results in the application hanging on exit.

o Kerberos support - On Solaris, HP-UX, and IBM AIX, MIT Kerberos 5 version
  1.4 Kerberos clients are tested and supported. Other properly configured 
  GSS-API Kerberos clients are not tested or officially supported.

o LDAP support - On HP-UX only, the HP-provided LDAP libraries shipped in the
  LDAP-UX Integration product are tested and supported. Other properly
  configured LDAP libraries may function, but are not tested or officially
  supported.

o On AIX and HP, there is a problem when running a Java Virtual Machine within
  SQL Anywhere Server when the Java VM is using a different bitness than the 
  server. For example, using a 64-bit server with a 32-bit Java VM does not 
  work.

  To work around this issue, a script is provided in ${SQLANY12}/java that is
  used to start the Java VM. It relies on JAVA_HOME being set correctly. This
  script defaults to using a 32-bit Java VM. If you want to use a 64-bit Java 
  VM, change the value of JAVA_BITNESS to 64 in sa_java.sh.  
  
  If you want to use more than one Java VM, you should copy and modify
  sa_java.sh so that it loads your alternate Java VM. Then, set the
  java_location database option to point to the new script.

o On Red Hat Enterprise Linux, some Private Use characters may not display
  in Sybase Central, Interactive SQL (dbisql), the MobiLink Monitor, the SQL
  Anywhere Monitor, or the SQL Anywhere Console Utility (dbconsole).
  
  For the Unicode codepoints "U+E844" and "U+E863" (designated as private use
  characters) no glyphs are provided in any of the truetype fonts provided
  with the Red Hat Linux distribution. The characters in question are
  Simplified Chinese characters and are available in the Red Flag (Chinese
  Linux) distribution as part of their zysong.ttf (DongWen-Song) font.
		    
o On Red Hat Enterprise Linux, you may be unable to type in password 
  fields in Sybase Central, Interactive SQL, the MobiLink Monitor, or the
  SQL Anywhere Console Utility (dbconsole) if your computer is configured for a
  Far East language, such as Japanese or Chinese, and you are using KDE. To 
  work around this problem, turn off the Input Method Editor (IME).

  Click the Red Hat menu, and then click the "Settings/Input Method" menu item.
  This opens the "IM Chooser" window. Click "Never use input methods", 
  then click the "Close" button. Log out, and then log back in.
  


PHP driver
----------

o php-5.1.x may crash when using the SQLAnywhere driver.

  If the SQLAnywhere PHP driver is loaded using dl() and the driver cannot
  initialize properly, then PHP may crash if the PHP script declared any 
  functions.

  This behaviour is caused by a bug in PHP 5.1.x. There are three workarounds:

  1. Ensure that the SQL Anywhere environment is loaded properly and that the 
     SQL Anywhere PHP driver can load the dbcapi library.

  2. Avoid using dl() from scripts and load the module by adding an entry to 
     the php.ini file.

  3. Upgrade to PHP 5.2.x as this bug does not reproduce with the
     php-5.2.x releases. 
     
     
SQL Anywhere Monitor (Linux only)
---------------------------------

o SQL Anywhere Monitor reserves 1 GB of virtual address space at startup. You
  must ensure you have at least this amount available.  To display the 
  amount of virtual address space you are allowed, run:
	ulimit -v


Upgrading SQL Anywhere Monitor 11 to SQL Anywhere Monitor 12 (Linux only)
-------------------------------------------------------------------------

Uninstalling the Monitor removes the application, as well as the list of 
resources and collected metrics.

If you want to upgrade your 11.0.1 Monitor resources and metrics to version 12,
do not uninstall the older version of the Monitor until you have performed the
following steps:

1) Make a backup of your SQL Anywhere Monitor database.
2) Install a new version of the Monitor.
3) Migrate the resources and metrics.

Detailed instructions for migrating your data and settings from 11.0.1 to 12, 
are provided in:

    SQL Anywhere 12 - Changes and Upgrading > Upgrading to SQL Anywhere 12 
    > Upgrading the SQL Anywhere Monitor and migrating resources and metrics 

