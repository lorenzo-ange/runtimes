# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

panel_list()
############
{
    echo "panel_welcome panel_clickwrap panel_mode panel_samon_regkey panel_samon_regkey_error panel_components_and_destination panel_destination panel_locate_existing_install panel_samon_migration panel_icons panel_starting_install panel_running_install panel_samonitor_service panel_samon_post_install_info"
}

need_panel()
############
{
    case "$1" in
	panel_welcome)
	    true
	    ;;
	panel_clickwrap)
	    true
	    ;;
	panel_mode)
	    true
	    ;;
	panel_samon_regkey)
	    not is_upgrade
	    ;;
	panel_samon_regkey_error)
	    not is_upgrade && not is_key_valid
	    ;;
	panel_components_and_destination)
	    not is_upgrade && [ `get_num_available_packages` -gt 1 ]
	    ;;
	panel_destination)
	    not is_upgrade && not is_modify && [ `get_num_available_packages` = 1 ]
	    ;;
	panel_locate_existing_install)
	    is_upgrade || is_modify
	    ;;
	panel_samon_migration)
	    is_upgrade
	    ;;
	panel_icons)
	    has_feature ICONS && not is_upgrade
	    ;;
	panel_starting_install)
	    true
	    ;;
	panel_running_install)
	    true
	    ;;
	panel_samonitor_service)
	    not is_upgrade
	    ;;
	panel_samon_post_install_info)
	    true
	    ;;
	*)
	    echo "Internal Error"
	    signal_handler
	    ;;
    esac
}

samon_pre_install_actions()
###########################
{
    samon_pre_extract 1
}

samon_post_install_actions()
############################
{
    samon_post_extract 1

    selinux_setup
    dbupdhlpr -sm "`get_install_dir SA`"

    # These next couple of things we do are to accomodate the following:
    # 1. changes/fixes to icons (Application Menu items / shortcuts)
    # 2. changes/fixes to Asian font display issues for the Admin Tools
    if is_ebf; then
	if has_installed_icons; then
	    install_icons
	fi
	if has_feature ADMINTOOLS ; then
	    create_jre_fonts_fallback_link
	fi
    fi

    if is_upgrade ; then
	return
    fi

    license_server
    make_sa_config 1
    make_shortcuts

    script_samonitor_sh
    create_jre_fonts_fallback_link
    if get_install_icons ; then
	install_icons
    fi
}

samon_default_install_dir()
###########################
{
    echo "/opt/samonitor`get_major_version samonitor`"
}

get_package_name()
##################
{
    echo "$MSG_SAMON_DEPLOY_PACKAGE_NAME" `get_version_display samonitor`
}

get_menu_name()
###############
{
    echo "${MSG_SAMON_DEPLOY_PACKAGE_NAME} `get_major_version samonitor`"
}


install_samonitor_service()
###########################
{
    BINDIR=`get_install_dir BIN`
    BINsDIR=`get_install_dir BINS`

    # uninstall old services that will conflict with new one
    for oldsvc in `"$BINsDIR/dbsvc" -l | grep SAMonitor` ; do 
	if [ -n "${oldsvc}" ]; then
	    "$BINsDIR/dbsvc" -y -x ${oldsvc} >/dev/null 2>&1
	    "$BINsDIR/dbsvc" -y -disable ${oldsvc} >/dev/null 2>&1
	fi
    done

    "$BINDIR/samonitor.sh" install >/dev/null 2>&1
    if [ $? -eq 0 ]; then
	"$BINDIR/samonitor.sh" start >/dev/null 2>&1
	"$BINsDIR/samonitor" -s SAMonitor`get_version` >/dev/null 2>&1
	true
    else
	false
    fi
}

set_pre_install_action_function samon_pre_install_actions
set_post_install_action_function samon_post_install_actions
set_default_install_dir_cb samon_default_install_dir

