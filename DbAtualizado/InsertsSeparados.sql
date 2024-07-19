insert into login (log_user, log_email, log_senha, log_img, log_plano, log_waid) values ('Master','master.123@123','c2VuYWkuMTIz','img-placeholder','master','15550882003')
insert into contatos (con_WaId, con_nome, con_DataCadastro, con_BloqueadoStatus, log_id) values ('557988132044','Pedro🤠',GETDATE(), 0,1)
insert into atendentes (ate_email,ate_estado,ate_img,ate_Nome,ate_senha) values ('emailTeste@gmail.com',1,'placeholder.img','AtendenteTeste','atendente@123')

insert into menus (men_header, men_footer, men_body, log_id,men_tipo,men_title) values ('Empresas Senai','Todos direitos reservados', 'Seja Bem Vindo ao Nosso Robo de Atendimento, Antes de Falar Com Nossos Atendentes Por Favor Resposnda as Perguntas Abaixo Para Sabermos o Seu Problema, Tentaremos Resolver Sem Intervenção Humana Se Possivel!',1,'PrimeiraMensagem','Menu Inicial')
insert into menus (men_header, men_footer, men_body, log_id,men_tipo,men_title) values ('Empresas Senai','Todos direitos reservados', 'Por Favor Escolha Qual Parte das Finança Voce Esta Tendo Problemas',1,'MenuBot', 'Finanças')
insert into menus (men_header, men_footer, men_body, log_id,men_tipo,men_title) values ('Empresas Senai','Todos direitos reservados', 'Por Favor Escolha Qual Setor de Suporte Que Voce Deseja Ser Atendido',1,'MenuBot', 'Suporte')
insert into menus (men_header, men_footer, men_body, log_id,men_tipo,men_title) values ('Empresas Senai','Todos direitos reservados', 'Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema de Acesso Ao Sistema',1,'MenuBot', 'DificuldadeAcesso')
insert into menus (men_header, men_footer, men_body, log_id,men_tipo,men_title) values ('Empresas Senai','Todos direitos reservados', 'Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema de Pagamento',1,'MenuBot', 'DificuldadePagar')

select * from menus

--Exemplo de uma option com resposta de menu lembrando que a resposta guarda o id no caso da resposta ser um menu
--Options do Menu de Primeira Mensagem
--quando a option for do tipo de resposta interativa voce coloca o id do menu que e para ela responder no campo opt_resposta e no opt_tipo colocar MensagemDeRespostaInterativa
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(1,1,GETDATE(), 'Referente a Financeiro',0,'2','MensagemDeRespostaInterativa','Financeiro')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(1,1,GETDATE(), 'Referente a Suporte',0,'3','MensagemDeRespostaInterativa','Suporte')

--Exemplo de uma option com uma resposta simples + o finalizar atendimento

--Options do Menu de DificuldadePagamento
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(5,1,GETDATE(), 'Pagamento Não Disponivel',1,'Sua Forma de Pagamento não esta disponivel no sistema? Use esse qrcode para pagar diretamente: (exemploqrcode)','MensagemDeResposta','DificuldadesSistemas')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(5,1,GETDATE(), 'Pagamento Não Autorizado',1,'Sinto Muito Pelo Transtorno se Possivel tente checkar seu saldo para ver se ouve uma transação erronea','MensagemDeResposta','DificuldadesSistemas')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(5,1,GETDATE(), 'Finalizar Atendimento',1,'Muito Obrigado Por Interagir','MensagemDeResposta','Finalizar2')

--Options do Menu de DificuldadeAcesso
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(4,1,GETDATE(), 'Esqueci Minha Senha',1,'Aqui Esta um Link Para Preencher as informações para o reset da sua senha: (linkExemplo), espero que fique bem.','MensagemDeResposta','DificuldadesSistemas')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(4,1,GETDATE(), 'Instabilidade No Geral',1,'Lamentamos se o sistema esta lento hoje, estamos em periodo de manuntenção ja voltaremos ao normal','MensagemDeResposta','DificuldadesSistemas2')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(4,1,GETDATE(), 'Finalizar Atendimento',1,'Obrigado Por Interagir Volte Sempre','MensagemDeResposta','Finalizar')

--Options do Menu de Finanças
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(2,1,GETDATE(), 'Dificuldades no Pagamento',0,'5','MensagemDeRespostaInterativa','Pagamento')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(2,1,GETDATE(), 'Finalizar Atendimento',1,'Muito Obrigado Por Interagir','MensagemDeResposta','Finalizar2')


--Options do Menu de Suporte
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(3,1,GETDATE(), 'Instabilidade no Geral',0,'4','MensagemDeRespostaInterativa','DificuldadesSistemas')
insert into options (men_id, log_id, opt_data, opt_descricao, opt_finalizar, opt_resposta,opt_tipo, opt_title) values(3,1,GETDATE(), 'Finalizar Atendimento',1,'Muito Obrigado Por Interagir Volte Sempre','MensagemDeResposta','Finalizar')

select * from options