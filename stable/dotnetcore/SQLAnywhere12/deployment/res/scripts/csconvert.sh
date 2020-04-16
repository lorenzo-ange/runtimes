# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

CS_TARGET_CHARSET=""

set_target_charset()
####################
{
    CS_TARGET_CHARSET="${1:-}"
}

get_target_charset()
####################
{
    echo "${CS_TARGET_CHARSET:-}"
}
