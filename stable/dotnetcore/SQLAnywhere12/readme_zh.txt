SQL Anywhere 12.0.1 发行说明（用于 Unix 和 Mac OS X）

Copyright (c) 2014, iAnywhere Solutions, Inc.
All rights reserved. All unpublished rights reserved.


安装 SQL Anywhere 12
--------------------------

1. 切换至已创建的目录，并通过运行
以下命令启动安装程序脚本：
cd ga1201
        ./setup

   有关可用安装选项的完整列表，
请运行以下命令：
./setup -h

   对于 Mac OS X，提供了 GUI 安装程序。在 Finder 中双击
“安装 SQL Anywhere”。

2. 按照安装程序中的说明操作。


安装说明
------------------

o 已删除在 64 位操作系统上安装 32 位 
MobiLink 服务器的功能。在可以正常安装 32 位 MobiLink 服务器的
64 位 UNIX 平台上，选项将更改为仅包括
MobiLink 客户端组件。

  为了升级 12.0.0 版本，32 位 MobiLink 服务器组件
将升级到 12.0.1 版本，但 mlsrv12 将会报错
且不能启动。

o Linux 安装程序能够在 Linux 系统中创建“应用程序”菜单项。
在安装完成之后到“应用程序”菜单发生更改之前，
还需要几分钟时间。在一些 Linux 发布版本上，
需要先注销然后再登录，更改才会生效。


文档
-------------

文档可在 DocCommentXchange 上获取，网址为：
http://dcx.sybase.com

DocCommentXchange 是在 Web 上访问和讨论
SQL Anywhere 文档的在线社区。DocCommentXchange 是
SQL Anywhere 12 的缺省文档格式。

如果您希望使用文档的本地副本，
可通过以下网址安装文档：
www.sybase.com/detail?id=1069195

对于日文版本的客户，可通过以下网址安装文档：
http://www.ianywhere.jp/developers/product_manuals/sqlanywhere/index.html


SQL Anywhere 论坛
---------------------------

SQL Anywhere 论坛是一个网站，您可以在其中
提出及回答关于 SQL Anywhere 软件的问题，
并对他人的问题及回答进行评论和投票。可以通过以下网址访问 SQL Anywhere 论坛：
http://sqlanywhere-forum.sybase.com。


设置 SQL Anywhere 12 的环境变量
-------------------------------------------------

每个使用该软件的用户都必须设置必要的 SQL Anywhere
环境变量。这些变量的设置取决于您使用的特定操作系统，
具体内容在文档中的“SQL Anywhere 服务器 - 数据库管理 >
配置数据库 > SQL Anywhere 环境变量”中讨论。


SQL Anywhere 12 的发行说明
---------------------------------


SQL Anywhere 服务器
-------------------

o SQL Anywhere 服务器 - 必须重建
SQL Anywhere 9 和更早版本的数据库，才能与 SQL Anywhere 12 共同使用。
安装 SQL Anywhere 12 后，请查阅文档以了解有关
重建数据库的信息。

  重建用于 Mac OS X 计算机的数据库时，
必须执行以下一项操作：
o 在另一个平台上重建数据库。
o 卸载运行其他平台的计算机上的数据库，然后在
Mac OS X 上重新加载。
o 卸载使用数据库服务器版本 9 的 Mac OS X 上的数据库，
然后使用软件版本 12 重新加载数据库。

o 如果使用 SQL Anywhere 9.0.1 或更早版本的服务器软件，
SQL Anywhere 12 的 64 位客户端可能无法使用共享内存
连接到数据库服务器。要解决这一限制问题，可使用
TCP/IP 进行通信，或将服务器升级到 SQL Anywhere 9.0.2 或
SQL Anywhere 12。

  对于 HP-UX Itanium，还存在一些其它限制。9.0.2（内部版本 3207）之前版本
（包括更早的版本）中的客户端或服务器无法与
使用共享内存的 SQL Anywhere 12 中的服务器或客户端进行通信。即使
客户端和服务器都为 32 位或都为 64 位，
这种限制也仍然存在。要解决这一限制问题，可使用 TCP/IP 进行通信，
或将旧版软件升级到 Adaptive Server Anywhere 9.0.2（内部版本 3207）或
更高版本，或者升级到 SQL Anywhere 12。

o SQL Anywhere 服务器 – 在 RedHat 4 上，如果启动支持 GUI 的数据库服务器，
可能会由于 glibc 错误而导致崩溃。对 glibc 2.3.4-2.25
进行测试表明该问题已经解决。建议至少在
此补丁级别运行 glibc。

o SQL Anywhere 服务器 - 在内核版本低于 2.6.13 的 Linux 发布版本上，
由于一个已知的内核错误，链接范围的本地 IPv6 地址可能不能
如期工作。如果需要使用链接范围的本地 IPv6 地址，
建议至少将内核升级到 2.6.13 版本。

o SQL Anywhere 服务器 – 在 Mac OS X 上，当计算机处于休眠模式时，
网络连接停止。因此，当 Mac 计算机处于休眠模式时，
将无法与该 Mac 机上运行的 SQL Anywhere 服务器连接。为避免出现此问题，
可将休眠模式设置为“永不”。从“系统首选项”选择“睡眠模式”。在“休眠”选项卡上，
将滑块移动到“永不”。

o SQL Anywhere 服务器 - 在 AIX 5.3 上，建议至少
使用编号为 IY79612 的补丁程序，因为 syslogd 中的错误
可导致 SQL Anywhere 服务器挂起。

o SQL Anywhere 服务器 - 在 AIX 上，由于 VM 错误而导致数据库中的 Java 支持
并不支持 Java/JRE 1.6。此问题的错误报告
已提交到 IBM。

o SQL Anywhere 服务器 - 在内核版本高于 2.6.13 的 Linux 上，
在磁带驱动器上备份或恢复可能会失败。在 2.6.29.1 之前，
可能会出现“设备或资源正忙”错误。该错误已在内核中
修复（参见内核错误 12207）。在 2.6.29.1 之后，可能
仍然会遇到 I/O 错误。

o SQL Anywhere 服务器 - 在采用 AMD64 体系结构的 Solaris 10 中，数据库
服务器可能会在关机时崩溃。应用 Solaris 补丁程序 118345 和 119964 可
修复此问题。

o SQL Anywhere 服务器 – Perl 外部环境 - 在 Mac OS X Lion (10.7) 上，如果缺省情况下在 perlenv 目录中
运行以下命令：

    perl Makefile.PL

  ，则会将 perl 视为 64 位。这将导致
lib64 中存在一个 libdbextenv12_r.dylib 的预期结果，
但实际情况并非如此。

  为解决此问题，必须在设置以下环境
变量的情况下调用 perl：

    $ export VERSIONER_PERL_PREFER_32_BIT=yes

  也可以在系统级更改缺省设置：

    # defaults write com.apple.versioner.perl Prefer-32-Bit -bool yes


管理工具
--------------------

o 在 64 位 Linux 发布版本中，要使用管理工具，
必须安装 32 位兼容库。尤其需要 32 位
X11 库。在 Ubuntu 上运行：
	sudo apt-get install ia32-libs

  在 RedHat 上运行：
	yum install glibc.i686

  If you do not install these libraries, the operating system cannot
  load the administration tools' binaries. When the load fails,
  you see an error like:

  -bash: /opt/sqlanywhere12/bin32/dbisql: No such file or directory


o 在某些亚洲区域设置中，缺省情况下图形管理工具无法始终
正确地显示亚洲字符。

  显示问题主要是由于缺少字体配置
文件（JRE 的 lib 目录中前缀为 fontconfig 的文件）所导致。在某些情况下，
可以从操作系统服务商处获得操作系统的字体配置文件和
语言组合。阅读下面与您的操作系统最相关的章节。
如果没有适用的章节，尝试“其它”一节中的步骤。



  Red Flag 5（中文）

  确保已为简体中文区域设置安装了
以下 RPM：
ttfonts-zh_CN-5.0-2

  如果尚未安装，可在 RedFlag 5 发布版本的 CD #2 上找到该 RPM。

  当以根用户身份登录时，可使用 "rpm -i" 命令来
安装 RPM。

  运行以下命令，这样 JRE 便能找到您的系统的
字体配置文件：

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.Linux.properties

  您也可以将 zysong.ttf 文件复制到 JRE 的字体
目录中。

  运行以下命令，这样 JRE 就会找到相应字体:

  1. cd /usr/share/fonts/zh_CN/TrueType

  2. mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. cp zysong.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  Red Flag Linux Desktop 6

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 运行以下命令，这样 JRE 就会找到相应字体:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/zh_CN/TrueType/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  RedHat Enterprise Linux 4

  确保已安装了亚洲区域设置所需的字体。如果尚未安装，可在 Redhat Enterprise Linux 4 发布版本
的 CD #4 上找到该 RPM。

  以下 RPM 包含亚洲区域设置所需的字体:

           ttfonts-ja-1.2-36.noarch.rpm
           ttfonts-ko-1.0.11-32.2.noarch.rpm
           ttfonts-zh_CN-2.14-6.noarch.rpm
           ttfonts-zh_TW-2.11-28.noarch.rpm

  当以根用户身份登录时，可使用 "rpm -i" 命令来
安装这些 RPM 中的每一个 RPM。

  运行以下命令，这样 JRE 便能找到您的系统的
字体配置文件：

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.RedHat.4.properties



  RedHat Enterprise Linux 5

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 确保已安装显示亚洲语言所需的
字体。目前，可访问以下 Red Hat 网址获得
安装字体的指导：

     www.redhat.com/docs/manuals/enterprise/RHEL-5-manual/en-US/Internationalization_Guide.pdf

  3. 然后管理工具便应能够显示亚洲字体而无需进一步操作。




  RedHat Enterprise Linux 6

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 确保已安装显示亚洲语言所需的语言支持和字体。


  3. 运行以下命令，这样 JRE 就会找到相应字体:

       ln -s /usr/share/fonts/cjkuni-ukai/ukai.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback/ukai.ttc



  SUSE 10

  确保已安装了亚洲区域设置所需的字体。如果尚未安装，可在 SuSE 10 发布版本的 CD 上找到 RPM。


	  sazanami-fonts-20040629-7.noarch.rpm		    (CD #1)
	  unfonts-1.0.20040813-6.noarch.rpm		    (CD #2)
	  ttf-founder-simplified-0.20040419-6.noarch.rpm    (CD #1)
	  ttf-founder-traditional-0.20040419-6.noarch.rpm   (CD #1)

  如果这些字体不包含您要显示的字符，请尝试
“其它”一节中的步骤。

  当以根用户身份登录时，可使用 "rpm -i" 命令来
安装这些 RPM 中的每一个 RPM。

  运行以下命令，这样 JRE 就会找到相应字体:

  1. ln -s /usr/X11R6/lib/X11/fonts/truetype $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  注意:在登录提示时设置语言并不足以使
JRE（以及管理工具）确定区域设置。启动管理工具之前，
应将环境变量 LANG 设置为以下值之一：


           ja_JP
           ko_KR
           zh_CN
           zh_TW

  例如，在 Bourne shell 及其衍生 shell 下，在启动管理工具之前运行以下命令：


        export LANG=ja_JP

  如果将区域设置设为 de_DE.UTF-8，则窗口标题栏中不显示某些德语
字符（例如，带变音符号的 "a"）。
解决此问题的方法是使用 de_DE@euro 区域设置。

  有关此环境变量的有效区域设置的完整列表，
请参见 /usr/lib/locale 目录清单。



  SUSE 11 Linux Enterprise Server

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 运行“控制中心”，单击“语言”，在语言列表中
选择“日语”（示例）。单击“确定”。

  3. 运行以下命令:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 8.10

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 运行以下命令:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/kochi/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 9.10

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 运行以下命令:

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ln -s /usr/share/fonts/truetype/vlgothic/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 10.04 和 11.04

  1. 关闭任意运行中的图形管理工具（Sybase Central、Interactive SQL (dbisql)、
MobiLink 监控器、SQL Anywhere 监控器或
SQL Anywhere 控制台应用程序 (dbconsole)）。

  2. 运行以下命令：

	mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. 运行以下命令中的一条或多条以启用指定语言的字体：

     JAPANESE:
	ln -s /usr/share/fonts/truetype/takao/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback


     SIMPLIFIED CHINESE:
	ln -s /usr/share/fonts/truetype/arphic/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback
	ln -s /usr/share/fonts/truetype/wqy/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback


  其它

  如果您的发布版本类型相同，但版本号与以上章节中列出
的版本号不同，建议您尝试执行最相关部分中的步骤，
并根据需要修改为不同的版本号。
您还应在 Internet 中搜索，查找适合您的
发布版本的具体解决方案。如果执行完这些步骤后仍然未能得到
满意的解决方案，则可使用下面的一般解决方案。

  执行下面的过程可将 Unicode、TrueType 字体安装到
管理工具所使用的 JRE 中。该方法可用于上面未提及的任何
Linux 操作系统。其它 TrueType 字体可通过
类似方式安装。

  1. 关闭所有正在运行的管理工具。

  2. 下载可免费获取的 Unicode 字体，如 Bitstream Cyberbit，
可从以下网址获得：

     ftp://ftp.netscape.com/pub/communicator/extras/fonts/windows/Cyberbit.ZIP

  3. 将 Cyberbit.ZIP 解压缩到临时目录。

  4. 创建目录 $SQLANY12/sun/jre160_x86/lib/fonts/fallback。

  5. 将 Cyberbit.ttf 复制到 $SQLANY12/sun/jre160_x86/lib/fonts/fallback 目录中。



MobiLink
--------

o MobiLink 服务器需要 ODBC 驱动程序才能与
统一数据库通信。可通过以下链接从 Sybase 主页
找到推荐用于所支持的统一数据库的
ODBC 驱动程序：
http://www.sybase.com/detail?id=1011880

o 有关 MobiLink 支持的平台的信息，请参见：
http://www.sybase.com/detail?id=1002288

o 在 iPhone 上使用 UltraLite 时，如果要建立端对端加密链接，MobiLink 可能会偶发性报告以下错误：


    “流错误: 不匹配的端对端加密密钥”

  出现这种错误的几率很小。此问题应在第一个 EBF 中得到解决。



QAnywhere
---------

o 现在没有内容。


UltraLite
---------

o 现在没有内容。


操作系统支持
------------------------

o 可在 http://www.ianywhere.com/products/supported_platforms.html 找到
安装 SQL Anywhere 12 的操作系统要求。
此网页还包含有关每个支持的平台所附带的
SQL Anywhere 组件的信息。

o 64 位 Linux 支持 – 某些 64 位 Linux 操作系统不包含
预安装的 32 位兼容库。要使用 32 位软件，
需要为您的 Linux 发布版本安装 32 位兼容库。
例如，在 Ubuntu 上，可能需要运行以下
命令：
	sudo apt-get install ia32-libs

  在 RedHat 上运行：
	yum install glibc.i686
	yum install libpk-gtk-module.so
	yum install libcanberra-gtk2.i686
	yum install gtk2-engines.i686

o Linux 对 dbsvc 的支持 - dbsvc 实用程序需要使用 LSB 初始化函数。
某些 Linux 操作系统缺省情况下不包含这些预安装的函数。
要使用 dbsvc，需要为 Linux 发布版本安装这些函数。
例如，在 Fedora 上运行以下命令：
	yum install redhat-lsb redhat-lsb.i686

o SELinux 支持 – 如果在 SELinux 上运行 SQL Anywhere 时出现问题，
您有以下几种选择：

  o 重新标记共享库，以便可以加载。此解决方案
在 Red Hat Enterprise Linux 5 上有效，但缺点是不使用
 SELinux 功能。
	find $SQLANY12 -name "*.so" | xargs chcon -t textrel_shlib_t 2>/dev/null

  o 安装随 SQL Anywhere 12 提供的策略。在安装的 selinux 目录
中有策略源。请参见此目录中
的 README 文件来了解构建和安装此策略的说明。


  o 编写您自己的策略。您可能希望以随 SQL Anywhere 12 提供的策略为基础进行编写。


  o 禁用 SELinux：
/usr/sbin/setenforce 0

o 线程和信号 – 软件中使用的线程和信号的类型
非常重要，因为某些系统可能耗尽这些资源。


    o 在 Solaris 中，SQL Anywhere 使用 POSIX 线程和本地信号。


    o 在 Linux、AIX、HP-UX 和 Mac OS X 中，SQL Anywhere 使用
pthreads（POSIX 线程）和系统 V 信号。

      Note: On platforms where System V semaphores are used, if the database
      server or a client application is terminated with SIGKILL, then System V
      semaphores are leaked. You must manually clean them up by using the
      ipcrm command.  In addition, client applications that terminate using
      the _exit() system call also leak System V semaphores unless the
      SQL Anywhere client libraries (such as ODBC and DBLib) are unloaded
      before this call.

o 警报处理 – 仅当开发非线程应用程序并使用 SIGALRM 或 SIGIO 处理程序时才有用。


  SQL Anywhere 在非线程客户端使用 SIGALRM 和 SIGIO 处理程序并启动重复警报（每 200 毫秒一次）。
为了实施正确的行为，
必须允许 SQL Anywhere 处理这些信号。

  如果在装载任何 SQL Anywhere 库之前定义 SIGALRM 或 SIGIO 处理
程序，则 SQL Anywhere 会链接到这些处理程序。
如果在装载任何 SQL Anywhere 库之后定义处理程序，
则需要从 SQL Anywhere 处理程序进行链接。

  如果使用 TCP/IP 通信协议，则 SQL Anywhere 将只在
非线程客户端使用 SIGIO 处理程序。该处理程序始终都会安装，
但只在您的应用程序使用 TCP/IP 时才使用。

o 建议用于 RedHat 4 x86_64 的补丁程序 – 由于 glibc 错误，在启动支持 GUI 的 64 位数据库服务器
时可能导致崩溃。使用 RedHat 的最新 glibc 补丁程序可以解决这个问题。


o HP Itanium 上的 iAnywhere JDBC 驱动程序 – 如果打算在 HP Itanium 上使用 iAnywhere JDBC 驱动
程序，则最低 JRE 版本要求为 1.4.2 版。使用 1.4.2 之前的任何版本将导致应用程序在退出时挂起。


o Kerberos 支持 – 在 Solaris、HP-UX 和 IBM AIX 上，
MIT Kerberos 5 版本 1.4 Kerberos 客户端经过测试并受支持。其它正确配置的 GSS-API Kerberos 客户端未经过测试或未得到正式支持。


o LDAP 支持 – LDAP-UX 集成
产品中随附 HP 提供的 LDAP 库，该库经过测试并受支持（仅在 HP-UX 上）。其它正确配置的 LDAP 库也可能正常工作，
但未经过测试或未得到正式支持。


o 在 AIX 和 HP 上，当在 SQL Anywhere 服务器内
运行 Java 虚拟机时，如果 Java VM 所使用的位与服务器不同，则会出现问题。
例如，将 64 位服务器与 32 位 Java VM 一起使用将无法工作。


  为解决此问题，在 ${SQLANY12}/java 中提供了一个用于启动 Java VM 的脚本。
它依赖于正确设置的 JAVA_HOME。该脚本缺省使用 32 位 Java VM。
如果要使用 64 位的 Java VM，在 sa_java.sh 内
将 JAVA_BITNESS 的值更改为 64。

  如果要使用多个 Java VM，应复制并修改 sa_java.sh，这样它才会
装载替代的 Java VM。然后设置 java_location 数据库选项以指向新脚本。


o 在 Red Hat Enterprise Linux 上，某些专用字符
在 Sybase Central、Interactive SQL (dbisql)、MobiLink 监控器、SQL Anywhere 监控器
或 SQL Anywhere 控制台实用程序 (dbconsole) 中可能不显示。

  对于 Unicode 代码点 "U+E844" 和 "U+E863"（指定为专用字符），
在随 Red Hat Linux 发布版本提供的任何 truetype 字体中，
均不提供轮廓。上述字符是简体中文字符，在 Red Flag（中文版 Linux）发布版本
中作为 zysong.ttf (DongWen-Song) 字体的一部分提供。


o 在 Red Hat Enterprise Linux 5 上，如果计算机配置为远东语言（如日文或中文）且使用 KDE，
则可能无法在 Sybase Central、Interactive SQL、MobiLink 监控器
或 SQL Anywhere 控制台实用程序 (dbconsole) 中在口令字段内键入内容。
要解决此问题，请关闭输入法编辑器 (IME)。


  单击 Red Hat 菜单，然后单击“设置/输入方法”(Settings/Input Method) 菜单项。
这将打开“IM 选择器”(IM Chooser) 窗口。单击“始终不使用输入方法”(Never use input methods)，
然后单击“关闭”(Close) 按钮。注销后再登录。



PHP 驱动程序
----------

o 使用 SQLAnywhere 驱动程序时 php-5.1.x 可能崩溃。

  如果使用 dl() 装载 SQLAnywhere PHP 驱动程序，而该驱动程序无法
正确初始化，则在 PHP 脚本声明任何函数时，PHP 都可能会崩溃。


  这是由于 PHP 5.1.x 中的错误导致的。有三个解决方案:

  1. 确保正确装载了 SQL Anywhere 环境，并且 SQL Anywhere PHP 驱动
程序能够装载 dbcapi 库。

  2. 避免在脚本中使用 dl()，通过在 php.ini 文件中添加条目来
装载模块。

  3. 升级到 PHP 5.2.x，因为 php-5.2.x 版本不再出现此错误。



SQL Anywhere 监控器（仅适用于 Linux）
---------------------------------

o SQL Anywhere 监控器在启动时保留 1 GB 的虚拟地址空间。您必须确保至少有此数量的空间可用。
要显示所允许的虚拟地址空间大小，请运行：
	ulimit -v



将 SQL Anywhere 监控器 11 升级到 SQL Anywhere 监控器 12（仅适用于 Linux）
-------------------------------------------------------------------------

卸载监控器会移除应用程序以及一列资源和已收集的度量。


如果要将 11.0.1 版监控器资源和度量升级到版本 12，
则在执行以下步骤之前请勿卸载旧版本的监控器：


1) 备份 SQL Anywhere 监控器数据库。
2) 安装新版本监控器。
3) 迁移资源和度量。

有关将数据和设置从 11.0.1 迁移到 12 的详细说明在以下位置提供：


    SQL Anywhere 12 - 更改和升级 > 升级到 SQL Anywhere 12 
> 升级 SQL Anywhere 监控器并迁移资源和度量

