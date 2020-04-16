# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

is_redflag()
############
{
    if [ `plat_os` = "linux" ] ; then
	grep -q -s "Red Flag" /etc/issue >/dev/null
	if [ $? -ne 0 ]; then
	    false
	else
	    true
	fi
    else
	false
    fi
}

is_redhat()
###########
{
    if [ `plat_os` = "linux" ] ; then
	grep -q -s "Red Hat" /etc/issue >/dev/null
	if [ $? -ne 0 ]; then
	    false
	else
	    true
	fi
    else
	false
    fi
}

is_suse()
#########
{
    if [ `plat_os` = "linux" ] ; then
	grep -q -s -i "SuSE" /etc/issue >/dev/null
	if [ $? -ne 0 ]; then
	    false
	else
	    true
	fi
    else
	false
    fi
}

is_ubuntu()
###########
{
    if [ `plat_os` = "linux" ] ; then
	grep -q -s -i "Ubuntu" /etc/issue >/dev/null
	if [ $? -ne 0 ]; then
	    false
	else
	    true
	fi
    else
	false
    fi
}
