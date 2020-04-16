# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

deploy_wizard_mode()
####################
{
    echo "${DEPLOY_WIZARD_MODE:-LIST}"
}

set_deploy_wizard_mode()
########################
{
    case "$1" in
	LIST | TAR)
	    DEPLOY_WIZARD_MODE="$1"
	;;
    esac
}

generate_deployment_tar()
#########################
{
    pushd_quiet "`get_install_dir SA`"
    build_filelist
    tar cf "$1" -T "`get_filelist`"
    popd_quiet
}

save_deploy_file_list_to_file()
###############################
{
    build_filelist
    cp "`get_filelist`" "$1"
}
