#!/bin/sh

rm -f sqlanywhere.fc

while [ -n "$1" ] ; do
    sed "s|\${INSTALL_ROOT}|$1|g" sqlanywhere.fct >> sqlanywhere.fc
    shift
done
