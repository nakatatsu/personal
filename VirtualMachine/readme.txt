# インストールなどは以下参照
https://github.com/nakatatsu/personal/wiki/VirtualBox%EF%BC%8BVagrant%E3%81%A7Windows%E7%92%B0%E5%A2%83%E3%81%8B%E3%82%89Linux%E3%82%92%E4%BD%BF%E3%81%84%E3%81%9F%E3%81%84%E3%81%A8%E3%81%8D%E3%81%AE%E5%88%9D%E6%9C%9F%E8%A8%AD%E5%AE%9A%E3%83%A1%E3%83%A2

# 各ホストのIPと用途
ansible         192.168.10.100 # Ansibleの実行用
local-web       192.168.10.101 # ローカル環境のWEBサーバー
local-db        192.168.10.102 # ローカル環境のDBサーバー
development-web 192.168.10.103 # 開発環境のWEBサーバー
development-db  192.168.10.104 # 開発環境のDBサーバー

複数人開発なら開発環境は共用サーバーに置くのだが、個人開発のためローカルにおいている。

