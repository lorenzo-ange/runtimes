SQL Anywhere 12.0.1 UNIX 版および Mac OS X 版リリースノート

Copyright (c) 2014, iAnywhere Solutions, Inc.
All rights reserved. All unpublished rights reserved.


SQL Anywhere 12 のインストール
--------------------------

1. 作成されたディレクトリに移動し、次のコマンドを実行して
   設定スクリプトを開始します。
cd ga1201
        ./setup

   使用可能な設定オプションのリストを表示するには、
   次のコマンドを実行します。
./setup -h

   Mac OS X には GUI のセットアッププログラムがあります。Finder で 
   [SQL Anywhere のインストール] をダブルクリックします。

2. セットアッププログラムの指示に従います。


インストールに関する注意事項
------------------

o 32 ビット Mobile Link サーバーを 64 ビットのオペレーティング
  システムにインストールできないようにしました。通常は 32 ビット Mobile Link サーバーをインストールできる
  64 ビット UNIX プラットフォームでは、オプションで Mobile Link クライアント
  コンポーネントのみを含むように変更されます。

  バージョン 12.0.0 からのアップグレードの場合、32 ビット Mobile Link サーバー
  コンポーネントはバージョン 12.0.1 にアップグレードされますが、
  mlsrv12 はエラーが発生して、起動しません。

o Linux のインストール時に、Linux 上にアプリケーションメニューの項目を作成できます。
インストールの完了後、変更内容がアプリケーションメニューに反映される
  までに数分かかる場合があります。一部の Linux ディストリビューションでは、
  変更が表示される前にログアウトして、再度ログインする必要があります。


マニュアル
-------------

マニュアルは DocCommentXchange にあります。アドレスは次のとおりです。
http://dcx.sybase.com

DocCommentXchange は Web 上の SQL Anywhere マニュアルを参照して
議論するためのオンラインコミュニティです。DocCommentXchange は 
SQL Anywhere 12 のデフォルトのマニュアルセットです。

マニュアルのローカルコピーを使用したい場合は、次のサイトから
マニュアルをインストールできます。
www.sybase.com/detail?id=1069195

日本のお客様は、次のサイトからマニュアルをインストールできます。
http://www.ianywhere.jp/developers/product_manuals/sqlanywhere/index.html


SQL Anywhere フォーラム
------------------

SQL Anywhere フォーラムは、SQL Anywhere ソフトウェアに関する質問や
回答を投稿できる Web サイトです。他の投稿者の質問やその回答にコメントや
評価を加えることもできます。SQL Anywhere フォーラムのアドレスは次のとおりです。
    http://sqlanywhere-forum.sybase.com


SQL Anywhere 12 の環境変数の設定
-------------------------------------------------

ソフトウェアを使用するユーザーごとに、SQL Anywhere の環境変数を設定する
必要があります。必要な環境変数はオペレーティングシステムによって異なり、
『SQL Anywhere サーバー - データベース管理』>
「データベースの設定」>「SQL Anywhere の環境変数」で説明しています。


SQL Anywhere 12 のリリースノート
---------------------------------


SQL Anywhere Server
-------------------

o SQL Anywhere サーバー - SQL Anywhere 9 以前のデータベースを
  SQL Anywhere 12 で使用するには、データベースを再構築する必要があります。データベースの
  再構築については、SQL Anywhere 12 のインストール後に
  マニュアルを参照してください。

  Mac OS X コンピューター用にデータベースを再構築する場合は、
  次のいずれかの操作を行います。
o 別のプラットフォームでデータベースを再構築します。
o 別のプラットフォームを実行しているコンピューターにあるデータベースをアンロードしてから
      Mac OS X に再ロードします。
o バージョン 9 のデータベースサーバーを使用している Mac OS X にあるデータベースをアンロードし、
     バージョン 12 のソフトウェアを使用してデータベースを再ロードします。

o SQL Anywhere 9.0.1 以前のサーバーソフトウェアを使用している場合は、
  SQL Anywhere 12 64 ビットクライアントから、共有メモリを使用して
  データベースサーバーに接続できない場合があります。この制限を回避するには、通信に TCP/IP を使用するか、
  サーバーを SQL Anywhere 9.0.2 または SQL Anywhere 12 に
  アップグレードしてください。

  HP-UX Itanium では、さらに制限があります。バージョン 9.0.2 ビルド 3207
  より前のクライアントまたはサーバーは、共有メモリを使用して SQL Anywhere 12
  のクライアントまたはサーバーと通信することはできません。この
  制限はクライアントとサーバーの両方が 32 ビットまたは
  64 ビットであっても同じです。この問題を回避するには、TCP/IP を使用するか、
  古いバージョンのソフトウェアを Adaptive Server Anywhere 9.0.2 ビルド 3207 以降
  または SQL Anywhere 12 にアップグレードしてください。

o SQL Anywhere サーバー - RedHat 4 では、GUI を有効にしてデータベースサーバーを
  起動すると、glibc のバグが原因でクラッシュする可能性があります。テストにより、glibc 2.3.4-2.25
  では問題が解決していることがわかっています。これ以上のパッチレベルの glibc
  を実行することをおすすめします。

o SQL Anywhere サーバー - カーネルが 2.6.13 より前の Linuxディストリビューションでは、
  カーネルの既知のバグが原因で、IPv6 リンクスコープのローカルアドレスが
  正常に機能しない場合があります。リンクスコープのローカル IPv6 アドレスを使用する必要がある場合は、
  カーネルをバージョン 2.6.13 以降に更新することをおすすめします。

o SQL Anywhere サーバー - Mac OS X では、コンピューターがスリープモードになると、
  ネットワーク接続が停止します。このため、スリープモードになった Mac で実行されている
  SQL Anywhere サーバーには接続できません。この問題を回避するには、
  スリープモードを [しない] に設定します。システム環境設定から、[省エネルギー] を選択します。
  スライダーを [しない] まで移動します。

o SQL Anywhere サーバー - AIX 5.3 では、syslogd のバグが原因で SQL Anywhere サーバーが
  ハングする場合があるため、パッチ番号 IY79612 以降を適用することを
  おすすめします。

o SQL Anywhere サーバー - AIX では、VM のバグが原因で、
  データベース内の Java で Java/JRE 1.6 がサポートされていません。この問題については、
  バグレポートが IBM に提出されています。

o SQL Anywhere サーバー - カーネルバージョン 2.6.13 以降の Linux カーネルでは、
  テープドライブへのバックアップまたはテープドライブからのリストアが失敗する場合があります。2.6.29.1
  以前では、「デバイス、またはリソースが使用中です」というエラーが発生する場合があります。このエラーは、
  カーネルで修正されています (カーネルバグ 12207 を参照)。2.6.29.1 以降で、
  まだ I/O エラーが発生する場合があります。

o SQL Anywhere サーバー - AMD64 アーキテクチャ上の Solaris 10 で、シャットダウン時に
  データベースサーバーがクラッシュする場合があります。この問題は、Solaris のパッチ 118345 と
  119964 を適用すれば解決できます。

o SQL Anywhere Server、Perl 外部環境 - Mac OS X Lion (10.7) の perlenv ディレクトリで
  次のコマンドを実行すると、

    perl Makefile.PL

  デフォルトで perl のビット設定数は 64 ビットであると判断されます。この結果、lib64
  に libdbextenv12_r.dylib があると予期されますが、実際には
  このファイルはありません。

  この問題を回避するには、次の環境変数を設定して perl を
  実行する必要があります。

    $ export VERSIONER_PERL_PREFER_32_BIT=yes

  または、システムレベルで次のようにデフォルトを変更します。

    # defaults write com.apple.versioner.perl Prefer-32-Bit -bool yes


管理ツール
--------------------

o 64 ビット Linux ディストリビューションで管理ツールを使用するには、
  32 ビット互換性ライブラリをインストールします。特に、32 ビット
  X11 ライブラリが必要です。Ubuntu では次のコマンドを実行します。
	sudo apt-get install ia32-libs

  RedHat では次のコマンドを実行します。
	yum install glibc.i686

  If you do not install these libraries, the operating system cannot
  load the administration tools' binaries. When the load fails,
  you see an error like:

  -bash: /opt/sqlanywhere12/bin32/dbisql: No such file or directory


o 一部のアジアのロケールでは、グラフィカル管理ツールにデフォルトで
  アジアの文字が正常に表示されない場合があります。

  表示の問題は、フォント設定ファイル (JRE の lib ディレクトリにある fontconfig
  プレフィクスのファイル) がないことが主な原因です。特定のオペレーティング
  システムと言語の組み合わせのフォント設定ファイルを、オペレーティングシステムの
  ベンダーから入手できる場合があります。下記のうち、お使いのオペレーティング
  システムに該当する項を参照してください。該当する項目がない場合は、「その他」の
  項の手順を試してください。


  Red Flag 5 (中国語)

  簡体字中国語ロケール用の次の RPM がインストールされていることを
  確認します。
ttfonts-zh_CN-5.0-2

  インストールされていない場合、RedFlag 5 ディストリビューションの CD #2 の RPM を使用します。

  RPM をインストールするには、root でログインして "rpm -i" コマンドを
  実行します。

  次のコマンドを実行して、JRE でシステムのフォント設定ファイルが
  見つかるようにします。

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.Linux.properties

  または、zysong.ttf ファイルを JRE のフォントディレクトリに
  コピーします。

  次のコマンドを実行して JRE でフォントが見つかるようにします。

  1. cd /usr/share/fonts/zh_CN/TrueType

  2. mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. cp zysong.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  Red Flag Linux Desktop 6

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. 次のコマンドを実行して JRE でフォントが見つかるようにします。

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
ln -s /usr/share/fonts/zh_CN/TrueType/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  RedHat Enterprise Linux 4

  アジアのロケール用のフォントがインストールされていることを確認します。インストール
  されていない場合は、Redhat Enterprise Linux 4 ディストリビューションの CD #4 の RPM を使用します。

  次の RPM にアジアのロケールのフォントが含まれます。

           ttfonts-ja-1.2-36.noarch.rpm
ttfonts-ko-1.0.11-32.2.noarch.rpm
ttfonts-zh_CN-2.14-6.noarch.rpm
ttfonts-zh_TW-2.11-28.noarch.rpm

  これらの RPM をインストールするには、root でログインして
  "rpm -i" コマンドを実行します。

  次のコマンドを実行して、JRE でシステムの
  フォント設定ファイルが見つかるようにします。

  1. cd $SQLANY12/sun/jre160_x86/lib

  2. cp fontconfig.RedHat.3.properties.src fontconfig.RedHat.4.properties



  RedHat Enterprise Linux 5

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. アジア言語の表示に必要なフォントがインストールされていることを
     確認します。この文書の執筆時点では、フォントのインストールガイドが
      Red Hat の Web サイトで提供されています。

     www.redhat.com/docs/manuals/enterprise/RHEL-5-manual/en-US/Internationalization_Guide.pdf

  3. フォントがインストールされている場合は、管理ツールに
     アジアのフォントが表示されます。別途操作をする必要はありません。



  RedHat Enterprise Linux 6

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. アジア言語の表示に必要な言語サポートとフォントがインストールされていることを
     確認します。

  3. 次のコマンドを実行して JRE でフォントが見つかるようにします。

       ln -s /usr/share/fonts/cjkuni-ukai/ukai.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback/ukai.ttc



  SUSE 10

  アジアのロケール用のフォントがインストールされていることを確認します。インストール
  されていない場合、SuSE 10 ディストリビューション CD の RPM を使用します。

	  sazanami-fonts-20040629-7.noarch.rpm		    (CD #1)
	  unfonts-1.0.20040813-6.noarch.rpm		    (CD #2)
	  ttf-founder-simplified-0.20040419-6.noarch.rpm    (CD #1)
	  ttf-founder-traditional-0.20040419-6.noarch.rpm   (CD #1)

  表示する文字がこれらのフォントに含まれていない場合は、
  「その他」の項の手順を試してください。

  これらの RPM をインストールするには、root でログインして
  "rpm -i" コマンドを実行します。

  次のコマンドを実行して JRE でフォントが見つかるようにします。

  1. ln -s /usr/X11R6/lib/X11/fonts/truetype $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  注意 : JRE (および管理ツール) でロケールを決定するには、
  ログインプロンプトで言語を設定するだけでは不十分です。管理
  ツールを起動する前に、環境変数 LANG を次のいずれかの値に
  設定してください。

           ja_JP
ko_KR
zh_CN
zh_TW

  たとえば、Bourne シェルとその派生シェルでは、次のコマンドを
  実行してから管理ツールを起動します。

        export LANG=ja_JP

  一部のドイツ語の文字 (ウムラウト記号付きの "a" など) は、
  ロケールを de_DE.UTF-8 に設定しても、ウィンドウのタイトルバーに正常に表示されません。
この問題を回避するには、de_DE@euro ロケールを使用します。

  この環境変数の有効なロケール設定のリストについては、
  /usr/lib/locale のディレクトリリストを参照してください。



  SUSE 11 Linux Enterprise Server

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. Control Center を実行して [Language] をクリックします。
     次に、(たとえば) [Japanese] を選択して、[OK] をクリックします。

  3. 次のコマンドを実行します。

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
ln -s /usr/share/fonts/truetype/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 8.10

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. 次のコマンドを実行します。

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
ln -s /usr/share/fonts/truetype/kochi/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 9.10

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. 次のコマンドを実行します。

     mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback
ln -s /usr/share/fonts/truetype/vlgothic/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback



  UBUNTU 10.04 および 11.04

  1. 実行中のグラフィカル管理ツール (Sybase Central、Interactive
     SQL (dbisql)、Mobile Link モニター、SQL Anywhere モニター、
     SQL Anywhere コンソールユーティリティ (dbconsole)) をすべてシャットダウンします。

  2. 次のコマンドを実行します。

	mkdir $SQLANY12/sun/jre160_x86/lib/fonts/fallback

  3. 次の 1 つまたは複数のコマンドを実行して、各言語のフォントを有効にします。

     日本語:
	ln -s /usr/share/fonts/truetype/takao/*.ttf $SQLANY12/sun/jre160_x86/lib/fonts/fallback


     簡体中国語:
	ln -s /usr/share/fonts/truetype/arphic/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback
	ln -s /usr/share/fonts/truetype/wqy/*.ttc $SQLANY12/sun/jre160_x86/lib/fonts/fallback


  その他

  上記の項に示すディストリビューションとタイプが同じで
  バージョンが異なる場合は、最も関連する項の手順を、必要に応じて
  バージョン番号を置き換えて試すことをおすすめします。
  また、お使いのディストリビューションに
  固有の解決策をインターネットで検索してみてください。それでも解決できない場合は、
  次に示す一般的な解決策を使用します。

  Unicode、TrueType フォントを、管理ツールで使用される
  JRE にインストールする手順を次に示します。この手順は、上記にないすべての
  Linux オペレーティングシステムに使用できます。他の TrueType フォントも
  同様の方法でインストールできます。

  1. 管理ツールを実行している場合は終了します。

  2. 無料で提供されている Unicode フォントをダウンロードします。
     たとえば、Bitstream Cyberbit は次のサイトからダウンロードできます。

     ftp://ftp.netscape.com/pub/communicator/extras/fonts/windows/Cyberbit.ZIP

  3. Cyberbit.ZIP をテンポラリディレクトリに解凍します。

  4. $SQLANY12/sun/jre160_x86/lib/fonts/fallback ディレクトリを作成します。

  5. Cyberbit.ttf を $SQLANY12/sun/jre160_x86/lib/fonts/fallback
     ディレクトリにコピーします。


Mobile Link
--------

o Mobile Link サーバーでは、統合データベースと通信するために、
  ODBC ドライバーが必要です。サポートされている統合データベースの推奨
  ODBC ドライバーは、Sybase のホームページから入手できます。
  ホームページのリンクは次のとおりです。
http://www.sybase.com/detail?id=1011880

o Mobile Link でサポートされているプラットフォームの詳細については、次のサイトを参照してください。
http://www.sybase.com/detail?id=1002288

o iPhone の Ultra Light で、エンドツーエンド暗号化リンクを
  確立しようとすると、まれにですが、ランダムに Mobile Link で

    「ストリームエラー : エンドツーエンド暗号化キーが一致しません。」

  というエラーが表示される場合があります。この問題は、最初の
  EBF で解決されます。


QAnywhere
---------

o 現時点では何もありません。


Ultra Light
---------

o 現時点では何もありません。


オペレーティングシステムのサポート
------------------------

o SQL Anywhere 12 のインストールに関するオペレーティングシステムの
  稼働条件については、http://www.ianywhere.com/products/supported_platforms.html を参照してください。この Web ページ
  には、サポートされている各プラットフォームに含まれている
  SQL Anywhere のコンポーネントに関する情報もあります。

o 64 ビット Linux のサポート - 一部の 64 ビット Linux オペレーティングシステムには、
  32 ビット互換性ライブラリがプリインストールされていません。32 ビットのソフトウェアを
  使用するには、お使いの Linux ディストリビューション用の 32 ビット互換性ライブラリを
  インストールする必要があります。たとえば、Ubuntu では、次のコマンドを実行する
  必要があります。
	sudo apt-get install ia32-libs

  RedHat では次のコマンドを実行します。
	yum install glibc.i686
	yum install libpk-gtk-module.so
	yum install libcanberra-gtk2.i686
	yum install gtk2-engines.i686

o dbsvc に対する Linux のサポート - dbsvc ユーティリティを使用するには、LSB init ファンクションが必要です。
一部の Linux オペレーティングシステムには、これらがデフォルトでプレインストールされていません。
dbsvc を使用するには、Linux ディストリビューションからこれらをインストールする必要があります。
たとえば、Fedora では次のコマンドを実行します。
	yum install redhat-lsb redhat-lsb.i686

o SELinux のサポート - SELinux で SQL Anywhere を実行できない場合は、
  次の解決方法があります。

  o 共有ライブラリをロードできるようにラベルを変更します。この方法は
    Red Hat Enterprise Linux 5 で機能しますが、SELinux の機能を使用できない
    という欠点があります。
	find $SQLANY12 -name "*.so" | xargs chcon -t textrel_shlib_t 2>/dev/null

  o SQL Anywhere 12 に付属するポリシーをインストールします。インストールの
    selinux ディレクトリにポリシーのソースがあります。ポリシーの構築と
    インストールについては、このディレクトリ内の
    README ファイルを参照してください。

  o 独自のポリシーを作成します。SQL Anywhere 12 に付属するポリシーを
    テンプレートとして使用できます。

  o 次のように入力して SELinux を無効にします。
/usr/sbin/setenforce 0

o スレッドとセマフォ - ソフトウェアで使用されているスレッドと
  セマフォの種類は重要です。システムによっては、これらの
  リソースが不足する可能性があります。

    o Solaris では、SQL Anywhere で POSIX のスレッドと
      ネイティブのセマフォが使用されます。

    o Linux、AIX、HP-UX、Mac OS X では、SQL Anywhere で
      pthreads (POSIX スレッド) と System V のセマフォが使用されます。

      Note: On platforms where System V semaphores are used, if the database
      server or a client application is terminated with SIGKILL, then System V
      semaphores are leaked. You must manually clean them up by using the
      ipcrm command.  In addition, client applications that terminate using
      the _exit() system call also leak System V semaphores unless the
      SQL Anywhere client libraries (such as ODBC and DBLib) are unloaded
      before this call.

o アラーム処理 - この情報は、非スレッド化アプリケーションを
  開発し、SIGALRM または SIGIO のハンドラーを使用する場合にのみ関係します。

  SQL Anywhere では、非スレッド化クライアントで SIGALRM と
  SIGIO のハンドラーが使用され、200 ミリ秒ごとに繰り返しアラームが開始されます。処理が正常に
  行われるには、SQL Anywhere でこれらの信号を処理できる必要があります。

  SQL Anywhere のライブラリをロードする前に SIGALRM または
  SIGIO のハンドラーを定義すると、SQL Anywhere はこれらのハンドラーに接続されます。
SQL Anywhere のライブラリのロード後にハンドラーを
  定義した場合は、SQL Anywhere のハンドラーから接続する必要があります。

  TCP/IP 通信プロトコルを使用する場合、SQL Anywhere では、
  非スレッド化クライアントでのみ SIGIO のハンドラーが使用されます。このハンドラーは
  常にインストールされますが、使用されるのは、アプリケーションで TCP/IP を使用する場合だけです。

o RedHat 4 x86_64 に推奨されるパッチ - GUI を有効にして 64 ビットの
  データベースサーバーを起動すると、glibc のバグが原因でクラッシュする可能性があります。RedHat から
  提供されている glibc の最新パッチを適用すると問題は解決します。

o HP Itanium での iAnywhere JDBC ドライバー - HP Itanium で
  iAnywhere JDBC ドライバーを使用する場合は、1.4.2 以上の JRE が必要です。1.4.2 より前の
  JRE を使用すると、アプリケーションの終了時にハングします。

o Kerberos のサポート - Solaris、HP-UX、IBM AIX では、
  MIT Kerberos 5 バージョン 1.4 Kerberos クライアントがテスト済みで、サポート対象になっています。その他の正しく設定された
  GSS-API Kerberos クライアントはテストされておらず、正式なサポート対象ではありません。

o LDAP のサポート - HP-UX では、LDAP-UX Integration 製品に含まれる
  HP 提供の LDAP ライブラリだけがテスト済みで、サポート対象になっています。その他の
  正しく設定された LDAP ライブラリも機能する場合がありますが、
  テストされておらず、正式なサポート対象ではありません。

o AIX と HP では、Java 仮想マシンで SQL Anywhere サーバーとは
  異なるビットが使用されている場合、SQL Anywhere サーバー内で
  Java VM を実行すると問題が発生します。たとえば、64 ビットのサーバーで 32 ビットの Java VM を
  使用することはできません。

  この問題を回避するために、${SQLANY12}/java に Java VM を
  起動するためのスクリプトを用意しています。このスクリプトを実行するには、JAVA_HOME を正しく設定している必要があります。このスクリプトは、
  デフォルトで 32 ビットの Java VM を使用するように設定されています。64 ビットの Java VM を
  使用する場合は、sa_java.sh 内で JAVA_BITNESS の値を 64 に変更します。

  複数の Java VM を使用する場合は、sa_java.sh をコピーし、別の
  Java VM をロードするように変更します。次に、
  このスクリプトを参照するように java_location データベースオプションを設定します。

o Red Hat Enterprise Linux では、一部の私用文字が Sybase Central、
  Interactive SQL (dbisql)、Mobile Link モニター、または SQL
  Anywhere コンソールユーティリティ (dbconsole) で表示されない場合があります。

  Red Hat Linux ディストリビューションに付属するどの TrueType
  フォントにも、ユニコードのコードポイント "U+E844" と "U+E863"
  (私用文字) のグリフはありません。問題の文字は簡体字中国語の
  文字で、Red Flag (中国語版 Linux) ディストリビューションで
  zysong.ttf (DongWen-Song) フォントに含まれます。

o Red Hat Enterprise Linux では、コンピューターが日本語や
  中国語などの極東言語に設定されていて、KDE を使用している場合、
  Sybase Central、Interactive SQL、Mobile Link モニター、
  または SQL Anywhere コンソールユーティリティ (dbconsole) でパスワードのフィールドに入力できない場合があります。この
  問題を回避するには、Input Method Editor (IME) をオフにします。

  Red Hat メニューをクリックし、[Settings] の [Input Method] メニュー項目をクリックします。
[IM Chooser] ウィンドウが開きます。[Never use input methods] を
クリックし、[Close] ボタンをクリックします。一度ログアウトしてからまたログインします。



PHP ドライバー
----------

o SQLAnywhere ドライバーの使用時に php-5.1.x がクラッシュする場合があります。

  dl() を使用して SQLAnywhere PHP ドライバーがロードされていて、
  ドライバーが正常に初期化できない場合に PHP スクリプトで
  関数が定義されていると、PHP がクラッシュする場合があります。

  この動作は、PHP 5.1.x のバグが原因です。この問題は、次の 3 通りの方法で回避できます。

  1. SQL Anywhere 環境が正常にロードされ、SQL Anywhere PHP ドライバーが
     dbcapi ライブラリをロードできることを確認します。

  2. スクリプト内で dl() を使用しないようにし、php.ini ファイルに
     エントリを追加することでモジュールをロードします。

  3. PHP 5.2.x にアップグレードします。このバグは
     php-5.2.x リリースでは再現されません。


SQL Anywhere モニター (Linux のみ)
---------------------------------

o SQL Anywhere モニターでは、起動時に 1 GB の仮想アドレス領域が予約されます。
  少なくともこの容量を確保する必要があります。許可された
  仮想アドレス領域の容量を表示するには、次のコマンドを実行します。
	ulimit -v


SQL Anywhere モニター 11 から SQL Anywhere モニター 12 へのアップグレード (Linux のみ)
-------------------------------------------------------------------------

モニターをアンインストールすると、アプリケーション、
リソースと収集されたメトリックのリストが削除されます。

11.0.1 モニターのリソースとメトリックをバージョン 12 に
アップグレードする場合、次の手順を実行するまでは旧バージョンの
モニターをアンインストールしないでください。

1) SQL Anywhere モニターデータベースのバックアップを作成します。
2) 新しいバージョンのモニターをインストールします。
3) リソースとメトリックを移行します。

データと設定を 11.0.1 から 12 に移行する方法の詳細については、
次の資料で説明しています。

    『SQL Anywhere 12 - 変更点とアップグレード』>「SQL Anywhere 12 へのアップグレード」
>「SQL Anywhere モニターのアップグレードおよびリソースとメトリックの移行」

