# iAnywhere Solutions, Inc. One Sybase Drive, Dublin, CA 94568, USA
# Copyright (c) 2001-2012, iAnywhere Solutions, Inc. Portions copyright (c) 
# 1988-2012, Sybase, Inc. All rights preserved. All unpublished rights reserved.

read_version_field()
####################
{
    echo `dbversion -q -v "${2:-}" 2>/dev/null | grep "[[:space:]]${1:-}[[:space:]]" | cut -d ':' -f 2- 2>/dev/null`
}

find_product_tics()
###################
{
    product="${1:-sqlanywhere}"
    shift
    for tic in "$@" ; do
        tic=`eval echo ${tic}`
        if [ -n "${tic}" ] ; then
            tic_product=`read_version_field MODULE "${tic}"`
            if [ "${tic_product}" = "${product}" ] ; then
                echo ${tic}
                return
            fi
        fi
    done
}

get_version_field()
###################
{
    field="${1:-}"
    product="${2:-sqlanywhere}"

    fieldvarname="__VERSION_FIELD_${product}_${field}"
    fieldvar="\${${fieldvarname}:-}"
    if [ -z "`eval echo ${fieldvar}`" ]; then
        tic="`find_product_tic \"${product}\"`"
        value="`read_version_field \"${field}\" \"${tic:-}\"`"
        eval `echo ${fieldvarname}=\"${value}\"`
    fi

    echo `eval echo $fieldvar`
}


find_product_tic()
##################
{
    eval find_product_tics "${1:-sqlanywhere}" ${TICFILE:-}
}

get_major_version()
###################
{
    get_version_field VERSION_MAJOR "${1:-sqlanywhere}"
}


get_minor_version()
###################
{
    get_version_field VERSION_MINOR "${1:-sqlanywhere}"
}

get_patch_version()
###################
{
    get_version_field VERSION_PATCH "${1:-sqlanywhere}"
}

get_build_number()
##################
{
    get_version_field BUILD_NUMBER "${1:-sqlanywhere}"
}

get_version()
#############
{
    echo `get_major_version "${1:-sqlanywhere}"``get_minor_version "${1:-sqlanywhere}"``get_patch_version "${1:-sqlanywhere}"`
}

get_version_display()
#####################
{
    echo `get_major_version "${1:-sqlanywhere}"`.`get_minor_version "${1:-sqlanywhere}"`.`get_patch_version "${1:-sqlanywhere}"`
}

get_intended_os()
#################
{
    echo `get_version_field IDENT "${1:-sqlanywhere}"` | cut -d '/' -f 5 | cut -d ' ' -f 1
}

get_intended_hw()
#################
{
    tic="`find_product_tic \"${1:-sqlanywhere}\"`"
    echo `get_version_field IDENT "${1:-sqlanywhere}"` | cut -d '/' -f 4 | tr '[:upper:]' '[:lower:]'
}
