
# gittest.py
# @Author : BanMing
# @Date   : 2019/4/26 下午5:16:27
# @Desc   : 保证本地无修改

import subprocess

# 清除新建文件
subprocess.call("git clean -f")

# 还原修改文件
subprocess.call("git checkout .")

# 拉去
subprocess.call("git fetch")
subprocess.call("git pull")
