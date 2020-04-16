# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

push_rollback_callback()
########################
# $1 rollback function
# $* arguments
{
    __ROLLBACK="$* ; ${__ROLLBACK:-}"
}

rollback()
##########
{
    if [ "${__ROLLBACK_SAFE:-0}" -eq "1" ]; then
        eval `echo ${__ROLLBACK:-}`
    fi
}

rollback_safe_start()
#####################
# if cleanup is called during this time, we will roll back everything
{
    __ROLLBACK_SAFE=1
}

rollback_safe_end()
###################
# we've reached the end of the period in which rolling back is required
{
    __ROLLBACK_SAFE=0
}
