# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c)
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

get_lang_code()
###############
# Returns current language environment code
{
    case $LANG in
	ja* )
	    LANGCODE="ja"
	    ;;
	zh_HK* | zh_TW* | zh_SG* )
	    LANGCODE="en"
	    ;;
	zh* )
	    LANGCODE="zh"
           ;;
        de* )
	    LANGCODE="de"
           ;;
        fr* )
	    LANGCODE="fr"
           ;;
        * )
	    LANGCODE="en"
	    ;;
    esac
    echo $LANGCODE
}
