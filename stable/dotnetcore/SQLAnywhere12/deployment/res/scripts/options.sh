# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2009, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2009, Sybase, Inc. All rights preserved. All unpublished rights reserved.

has_feature()
############
{
    case "${1:-}" in
	SERVER_LICENSE)
	    (is_selected_option OPT_SQLANY64 || is_selected_option OPT_SQLANY32 || has_feature MOBILINK_SERVER || is_selected_option OPT_SAMON || is_selected_option OPT_SAMON_DEPLOY || is_selected_option OPT_DBCLOUD ) && not is_upgrade
	    ;;
	HIGH_AVAIL)
	    is_selected_option OPT_HIGH_AVAIL && not is_upgrade
	    ;;
	IN_MEMORY)
	    is_selected_option OPT_IN_MEMORY && not is_upgrade
	    ;;
	SCALEOUT_NODES)
	    is_selected_option OPT_SCALEOUTNODES && not is_upgrade
	    ;;
	SELINUX)
	    is_selected_option OPT_SELINUX
	    ;;
	ICONS)
	    test `plat_os` = "linux"
	    ;;
	ADMINTOOLS)
	    is_selected_option OPT_ADMINTOOLS
	    ;;
	SYBASE_CENTRAL)
	    is_selected_option OPT_ADMINTOOLS
	    ;;
	MOBILINK_SERVER)
	    has_feature MOBILINK_SERVER_32 || has_feature MOBILINK_SERVER_64
	    ;;
	MOBILINK_SERVER_32)
	    is_selected_option OPT_MLSRV32 || is_selected_option OPT_ML32
	    ;;
	MOBILINK_SERVER_64)
	    is_selected_option OPT_MLSRV64 || is_selected_option OPT_ML64
	    ;;
	SA_SERVER)
	    has_feature SA_SERVER_32 || has_feature SA_SERVER_64
	    ;;
	SA_SERVER_32)
	    is_selected_option OPT_SQLANY32
	    ;;
	SA_SERVER_64)
	    is_selected_option OPT_SQLANY64
	    ;;
	SAMPLES)
	    is_selected_option OPT_SAMPLES
	    ;;
	SAMON)
	    is_selected_option OPT_SAMON || is_selected_option OPT_SAMON_DEPLOY
	    ;;
	ECLIPSE)
	    is_selected_option OPT_ECLIPSE_EN_DOC || is_selected_option OPT_ECLIPSE_DE_DOC || is_selected_option OPT_ECLIPSE_JA_DOC || is_selected_option OPT_ECLIPSE_ZH_DOC
	    ;;
	DBCLOUD)
	    is_selected_option OPT_DBCLOUD
	    ;;
	DBCLOUD32)
	    is_selected_option OPT_DBCLOUD32
	    ;;
	DBCLOUD64)
	    is_selected_option OPT_DBCLOUD64
	    ;;
	*)
	    false
	    ;;
    esac
}

has_installed_feature()
#######################
{
    if has_feature "${1:-}"; then
        return 0
    fi

    case "${1:-}" in
	SERVER_LICENSE)
	    (is_installed_option OPT_SQLANY64 || is_installed_option OPT_SQLANY32 || has_installed_feature MOBILINK_SERVER || is_installed_option OPT_SAMON || is_installed_option OPT_SAMON_DEPLOY) && not is_upgrade
	    ;;
	HIGH_AVAIL)
	    is_installed_option OPT_HIGH_AVAIL && not is_upgrade
	    ;;
	IN_MEMORY)
	    is_installed_option OPT_IN_MEMORY && not is_upgrade
	    ;;
	SCALEOUT_NODES)
	    is_installed_option OPT_SCALEOUTNODES && not is_upgrade
	    ;;
	SELINUX)
	    is_installed_option OPT_SELINUX
	    ;;
	ICONS)
	    test `plat_os` = "linux"
	    ;;
	ADMINTOOLS)
	    is_installed_option OPT_ADMINTOOLS
	    ;;
	SYBASE_CENTRAL)
	    is_installed_option OPT_ADMINTOOLS
	    ;;
	MOBILINK_SERVER)
	    has_installed_feature MOBILINK_SERVER_32 || has_installed_feature MOBILINK_SERVER_64
	    ;;
	MOBILINK_SERVER_32)
	    is_installed_option OPT_MLSRV32 || is_installed_option OPT_ML32
	    ;;
	MOBILINK_SERVER_64)
	    is_installed_option OPT_MLSRV64 || is_installed_option OPT_ML64
	    ;;
	SA_SERVER)
	    has_installed_feature SA_SERVER_32 || has_installed_feature SA_SERVER_64
	    ;;
	SA_SERVER_32)
	    is_installed_option OPT_SQLANY32
	    ;;
	SA_SERVER_64)
	    is_installed_option OPT_SQLANY64
	    ;;
	SAMPLES)
	    is_installed_option OPT_SAMPLES
	    ;;
	SAMON)
	    is_installed_option OPT_SAMON || is_installed_option OPT_SAMON_DEPLOY
	    ;;
	ECLIPSE)
	    is_installed_option OPT_ECLIPSE_EN_DOC || is_installed_option OPT_ECLIPSE_DE_DOC || is_installed_option OPT_ECLIPSE_JA_DOC || is_installed_option OPT_ECLIPSE_ZH_DOC
	    ;;
	*)
	    false
	    ;;
    esac
}
