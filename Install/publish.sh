#! /bin/sh

# go to git folder
cd ~/src/Wuliao

# update resource
git pull

# copy to website
cp -R ~/src/Wuliao/Wuliao.Disrespect.Web/. /var/www/wuliao

# done