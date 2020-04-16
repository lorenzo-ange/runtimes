# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

signal_handler()
################
{
    rollback
    echo ${ERR_CLEANING_UP}
    clean_up_pre
    clean_up_post
    clear_signal_handler
    exit 1
}

set_signal_handler()
####################
{
    trap signal_handler HUP INT TERM
}

clear_signal_handler()
######################
{
    trap "" HUP INT TERM
}

