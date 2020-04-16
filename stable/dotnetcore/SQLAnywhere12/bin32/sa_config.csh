#!/bin/csh
#
echo "iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA"
echo "Copyright (c) 2001-2012, iAnywhere Solutions, Inc. Portions copyright (c) "
echo "1988-2012, Sybase, Inc. All rights reserved. All unpublished rights reserved."
echo 

# the following lines set the SA location.
setenv SQLANY12 "/home/photosi/source/sqlany"

[ -r "$HOME/.sqlanywhere12/sample_env32.sh" ] && source "$HOME/.sqlanywhere12/sample_env32.sh" 
if ( ! $?SQLANYSAMP12 ) then
    setenv SQLANYSAMP12 "/home/photosi/source/sqlany/samples"
endif

# the following lines add SA binaries to your path.
if ( $?PATH ) then
    setenv PATH "$SQLANY12/bin32:$SQLANY12/bin64:$PATH"
else
    setenv PATH "$SQLANY12/bin32:$SQLANY12/bin64"
endif
if ( $?LD_LIBRARY_PATH ) then
    setenv LD_LIBRARY_PATH "$SQLANY12/lib64:$LD_LIBRARY_PATH"
else
    setenv LD_LIBRARY_PATH "$SQLANY12/lib64"
endif
if ( $?LD_LIBRARY_PATH ) then
    setenv LD_LIBRARY_PATH "$SQLANY12/lib32:$LD_LIBRARY_PATH"
else
    setenv LD_LIBRARY_PATH "$SQLANY12/lib32"
endif
