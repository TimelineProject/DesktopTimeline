# TimelineProject
桌面应用版内部有数据库连接操作，请各位自行更改 我使用的是mysql数据库  
数据库有两张表  
第一张表名为  users  
里面有 user_id account 和 password 三个属性 user_id为int类型 长度255 为主键 account和password为varchar类型 长度255  全都不是null  
第二张表名为  infos  
里面有 user_id information image time 四个属性 user_id为int类型 长度为255 是外键约束 time为timestamp类型  infomation和image为varchar 255
其中 除了image以外全部不为空 无主键。  
  
users表的mysql语句  
CREATE TABLE `users` (  
  `account` varchar(255) NOT NULL,  
  `password` varchar(255) NOT NULL,  
  `user_id` int(255) NOT NULL AUTO_INCREMENT,  
  PRIMARY KEY (`user_id`)  
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;  
  
  
infos表的mysql语句  
CREATE TABLE `infos` (  
  `user_id` int(255) NOT NULL,  
  `information` varchar(255) NOT NULL,  
  `image` varchar(255) DEFAULT NULL,  
  `time` timestamp NOT NULL,  
  KEY `key` (`user_id`),  
  CONSTRAINT `key` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;  
  
