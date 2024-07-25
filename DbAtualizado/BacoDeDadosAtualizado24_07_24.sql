use master
go
drop database chatbot
go
create database chatbot
go
USE [chatbot]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[atendentes]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[atendentes](
	[ate_id] [int] IDENTITY(1,1) NOT NULL,
	[ate_email] [varchar](255) NULL,
	[ate_Nome] [varchar](255) NULL,
	[ate_img] [varchar](max) NULL,
	[ate_senha] [varchar](255) NULL,
	[ate_estado] [bit] NULL,
	[log_id] [int] NULL,
	[dep_id] [int] NULL,
 CONSTRAINT [PK__atendent__895194D674414920] PRIMARY KEY CLUSTERED 
(
	[ate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atendimento]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atendimento](
	[aten_id] [int] IDENTITY(1,1) NOT NULL,
	[aten_estado] [varchar](255) NULL,
	[aten_data] [datetime] NULL,
	[ate_id] [int] NULL,
	[dep_id] [int] NULL,
	[con_id] [int] NULL,
	[log_id] [int] NULL,
 CONSTRAINT [PK__Atendime__F4B66A4080C48752] PRIMARY KEY CLUSTERED 
(
	[aten_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chat]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chat](
	[cha_id] [int] IDENTITY(1,1) NOT NULL,
	[ate_id] [int] NULL,
	[log_id] [int] NULL,
	[con_id] [int] NULL,
	[aten_id] [int] NULL,
 CONSTRAINT [PK__chat__5AF8FDEA92B3BDD0] PRIMARY KEY CLUSTERED 
(
	[cha_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contatos]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contatos](
	[con_id] [int] IDENTITY(1,1) NOT NULL,
	[con_WaId] [varchar](255) NULL,
	[con_nome] [varchar](255) NULL,
	[con_DataCadastro] [datetime] NULL,
	[con_BloqueadoStatus] [bit] NULL,
	[log_id] [int] NULL,
 CONSTRAINT [PK__contatos__081B0F1A9391D70E] PRIMARY KEY CLUSTERED 
(
	[con_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamento]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[dep_id] [int] IDENTITY(1,1) NOT NULL,
	[dep_descricao] [varchar](255) NULL,
	[log_id] [int] NULL,
 CONSTRAINT [PK__departam__BB4BD8F8D55B4951] PRIMARY KEY CLUSTERED 
(
	[dep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[log_email] [varchar](255) NULL,
	[log_senha] [varchar](255) NULL,
	[log_img] [varchar](max) NULL,
	[log_plano] [varchar](255) NULL,
	[log_user] [varchar](255) NULL,
	[log_waid] [varchar](255) NULL,
 CONSTRAINT [PK__login__9E2397E023C6542C] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensagens]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensagens](
	[mens_id] [int] IDENTITY(1,1) NOT NULL,
	[mens_data] [datetime] NULL,
	[mens_descricao] [varchar](max) NULL,
	[men_tipo] [varchar](255) NULL,
	[con_id] [int] NULL,
	[log_id] [int] NULL,
	[cha_id] [int] NULL,
 CONSTRAINT [PK__Mensagen__763E9E0AC3136BFE] PRIMARY KEY CLUSTERED 
(
	[mens_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menus]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menus](
	[men_id] [int] IDENTITY(1,1) NOT NULL,
	[men_header] [varchar](255) NULL,
	[men_footer] [varchar](255) NULL,
	[men_body] [varchar](255) NULL,
	[log_id] [int] NULL,
	[men_tipo] [varchar](255) NULL,
	[men_title] [varchar](255) NULL,
 CONSTRAINT [PK__menus__387DDE002DE1152B] PRIMARY KEY CLUSTERED 
(
	[men_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[options]    Script Date: 7/23/2024 10:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[options](
	[opt_id] [int] IDENTITY(1,1) NOT NULL,
	[men_id] [int] NULL,
	[log_id] [int] NULL,
	[opt_data] [datetime] NULL,
	[opt_descricao] [varchar](500) NULL,
	[opt_finalizar] [bit] NULL,
	[opt_resposta] [varchar](500) NULL,
	[opt_tipo] [varchar](255) NULL,
	[opt_title] [varchar](24) NULL,
 CONSTRAINT [PK__options__84DB9F9B4CD6FC31] PRIMARY KEY CLUSTERED 
(
	[opt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240518192103_Migrationinicial', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240519041201_InitialCreate', N'8.0.5')
GO
SET IDENTITY_INSERT [dbo].[atendentes] ON 

INSERT [dbo].[atendentes] ([ate_id], [ate_email], [ate_Nome], [ate_img], [ate_senha], [ate_estado], [log_id], [dep_id]) VALUES (1, N'emailTeste@gmail.com', N'AtendenteTeste', N'placeholder.img', N'atendente@123', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[atendentes] OFF

GO
SET IDENTITY_INSERT [dbo].[login] ON 

INSERT [dbo].[login] ([log_id], [log_email], [log_senha], [log_img], [log_plano], [log_user], [log_waid]) VALUES (1, N'master.123@123', N'c2VuYWkuMTIz', N'img-placeholder', N'master', N'Master', N'557999411293')
SET IDENTITY_INSERT [dbo].[login] OFF
GO
SET IDENTITY_INSERT [dbo].[menus] ON 

INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (1, N'Empresas Senai', N'Todos direitos reservados', N'Seja Bem Vindo ao Nosso Robo de Atendimento, Antes de Falar Com Nossos Atendentes Por Favor Resposnda as Perguntas Abaixo Para Sabermos o Seu Problema, Tentaremos Resolver Sem Intervenção Humana Se Possivel!', 1, N'PrimeiraMensagem', N'Menu Inicial')
INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (2, N'Empresas Senai', N'Todos direitos reservados', N'Por Favor Escolha Qual Parte das Finança Voce Esta Tendo Problemas', 1, N'MenuBot', N'Finanças')
INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (3, N'Empresas Senai', N'Todos direitos reservados', N'Por Favor Escolha Qual Setor de Suporte Que Voce Deseja Ser Atendido', 1, N'MenuBot', N'Suporte')
INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (4, N'Empresas Senai', N'Todos direitos reservados', N'Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema', 1, N'MenuBot', N'Menu de Dificuldades ao Acessar o Sistema')
INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (5, N'Empresas Senai', N'Todos direitos reservados', N'Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema de Pagamento', 1, N'MenuBot', N'DificuldadePagar')
INSERT [dbo].[menus] ([men_id], [men_header], [men_footer], [men_body], [log_id], [men_tipo], [men_title]) VALUES (6,N'Empresas Senai', N'Todos direitos reservados', N'Escolha Quais Das Opções Abaixo e a Sua Vontade Se Tiver Mais Alguma Pergunta Apenas Pergunte!', 1, N'MenuDaIA', N'Menu IA')

SET IDENTITY_INSERT [dbo].[menus] OFF
GO
SET IDENTITY_INSERT [dbo].[options] ON 

INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (1, 1, 1, CAST(N'2024-07-19T11:07:40.017' AS DateTime), N'Referente a Financeiro', 0, N'2', N'MensagemDeRespostaInterativa', N'Financeiro')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (2, 1, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Referente a Suporte', 0, N'3', N'MensagemDeRespostaInterativa', N'Suporte')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (3, 5, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Pagamento Não Disponivel', 1, N'Sua Forma de Pagamento não esta disponivel no sistema? Use esse qrcode para pagar diretamente: (exemploqrcode)', N'MensagemDeResposta', N'Pagamento Indisponivel')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (4, 5, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Pagamento Não Autorizado', 1, N'Sinto Muito Pelo Transtorno se Possivel tente checkar seu saldo para ver se ouve uma transação erronea', N'MensagemDeResposta', N'Pagamento Não Autorizado')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (5, 5, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Finalizar Atendimento', 1, N'Muito Obrigado Por Interagir', N'MensagemDeResposta', N'Finalizar')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (6, 4, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Esqueci Minha Senha', 1, N'Aqui Esta um Link Para Preencher as informações para o reset da sua senha: (linkExemplo), espero que fique bem.', N'MensagemDeResposta', N'Esquecimento da Senha')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (7, 4, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Instabilidade No Geral', 1, N'Lamentamos se o sistema esta lento hoje, estamos em periodo de manuntenção ja voltaremos ao normal', N'MensagemDeResposta', N'Dificuldades Sistemas')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (8, 4, 1, CAST(N'2024-07-19T11:07:40.020' AS DateTime), N'Finalizar Atendimento', 1, N'Obrigado Por Interagir Volte Sempre', N'MensagemDeResposta', N'Finalizar')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (9, 2, 1, CAST(N'2024-07-19T11:07:40.023' AS DateTime), N'Dificuldades no Pagamento', 0, N'5', N'MensagemDeRespostaInterativa', N'Pagamento')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (10, 2, 1, CAST(N'2024-07-19T11:07:40.023' AS DateTime), N'Finalizar Atendimento', 1, N'Muito Obrigado Por Interagir', N'MensagemDeResposta', N'Finalizar')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (11, 3, 1, CAST(N'2024-07-19T11:07:40.023' AS DateTime), N'Instabilidade no Geral', 0, N'4', N'MensagemDeRespostaInterativa', N'Dificuldades Sistemas')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (12, 3, 1, CAST(N'2024-07-19T11:07:40.023' AS DateTime), N'Finalizar Atendimento', 1, N'Muito Obrigado Por Interagir Volte Sempre', N'MensagemDeResposta', N'Finalizar')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (13, 1, 1, CAST(N'2024-07-23T22:31:35.673' AS DateTime), N'Historia do Senai Contada Pela IA e Interação Geral Com IA', 0, NULL, N'MensagemPorIA', N'Historia Senai')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (14,6, 1, CAST(N'2024-07-23T22:31:35.673' AS DateTime), N'Voltar ao Fluxo de Atendimento Normal', 0, 'Sim', N'MensagemPorIA', N'Sim')
INSERT [dbo].[options] ([opt_id], [men_id], [log_id], [opt_data], [opt_descricao], [opt_finalizar], [opt_resposta], [opt_tipo], [opt_title]) VALUES (15, 6, 1, CAST(N'2024-07-23T22:31:35.673' AS DateTime), N'Finalizar o Atendimento', 1, 'Obrigado Por Interagir com O Sistema!', N'MensagemPorIA', N'Finalizar')
SET IDENTITY_INSERT [dbo].[options] OFF
GO
ALTER TABLE [dbo].[atendentes]  WITH CHECK ADD  CONSTRAINT [FK__atendente__dep_i__403A8C7D] FOREIGN KEY([dep_id])
REFERENCES [dbo].[departamento] ([dep_id])
GO
ALTER TABLE [dbo].[atendentes] CHECK CONSTRAINT [FK__atendente__dep_i__403A8C7D]
GO
ALTER TABLE [dbo].[atendentes]  WITH CHECK ADD  CONSTRAINT [FK__atendente__log_i__3F466844] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[atendentes] CHECK CONSTRAINT [FK__atendente__log_i__3F466844]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK__Atendimen__ate_i__4316F928] FOREIGN KEY([ate_id])
REFERENCES [dbo].[atendentes] ([ate_id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK__Atendimen__ate_i__4316F928]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK__Atendimen__con_i__44FF419A] FOREIGN KEY([con_id])
REFERENCES [dbo].[contatos] ([con_id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK__Atendimen__con_i__44FF419A]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK__Atendimen__dep_i__440B1D61] FOREIGN KEY([dep_id])
REFERENCES [dbo].[departamento] ([dep_id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK__Atendimen__dep_i__440B1D61]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK__Atendimen__log_i__45F365D3] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK__Atendimen__log_i__45F365D3]
GO
ALTER TABLE [dbo].[chat]  WITH CHECK ADD  CONSTRAINT [FK__chat__ate_id__48CFD27E] FOREIGN KEY([ate_id])
REFERENCES [dbo].[atendentes] ([ate_id])
GO
ALTER TABLE [dbo].[chat] CHECK CONSTRAINT [FK__chat__ate_id__48CFD27E]
GO
ALTER TABLE [dbo].[chat]  WITH CHECK ADD  CONSTRAINT [FK__chat__aten_id__4BAC3F29] FOREIGN KEY([aten_id])
REFERENCES [dbo].[Atendimento] ([aten_id])
GO
ALTER TABLE [dbo].[chat] CHECK CONSTRAINT [FK__chat__aten_id__4BAC3F29]
GO
ALTER TABLE [dbo].[chat]  WITH CHECK ADD  CONSTRAINT [FK__chat__con_id__4AB81AF0] FOREIGN KEY([con_id])
REFERENCES [dbo].[contatos] ([con_id])
GO
ALTER TABLE [dbo].[chat] CHECK CONSTRAINT [FK__chat__con_id__4AB81AF0]
GO
ALTER TABLE [dbo].[chat]  WITH CHECK ADD  CONSTRAINT [FK__chat__log_id__49C3F6B7] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[chat] CHECK CONSTRAINT [FK__chat__log_id__49C3F6B7]
GO
ALTER TABLE [dbo].[contatos]  WITH CHECK ADD  CONSTRAINT [FK__contatos__log_id__398D8EEE] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[contatos] CHECK CONSTRAINT [FK__contatos__log_id__398D8EEE]
GO
ALTER TABLE [dbo].[departamento]  WITH CHECK ADD  CONSTRAINT [FK__departame__log_i__3C69FB99] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[departamento] CHECK CONSTRAINT [FK__departame__log_i__3C69FB99]
GO
ALTER TABLE [dbo].[Mensagens]  WITH CHECK ADD  CONSTRAINT [FK__Mensagens__cha_i__5070F446] FOREIGN KEY([cha_id])
REFERENCES [dbo].[chat] ([cha_id])
GO
ALTER TABLE [dbo].[Mensagens] CHECK CONSTRAINT [FK__Mensagens__cha_i__5070F446]
GO
ALTER TABLE [dbo].[Mensagens]  WITH CHECK ADD  CONSTRAINT [FK__Mensagens__con_i__4E88ABD4] FOREIGN KEY([con_id])
REFERENCES [dbo].[contatos] ([con_id])
GO
ALTER TABLE [dbo].[Mensagens] CHECK CONSTRAINT [FK__Mensagens__con_i__4E88ABD4]
GO
ALTER TABLE [dbo].[Mensagens]  WITH CHECK ADD  CONSTRAINT [FK__Mensagens__log_i__4F7CD00D] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[Mensagens] CHECK CONSTRAINT [FK__Mensagens__log_i__4F7CD00D]
GO
ALTER TABLE [dbo].[menus]  WITH CHECK ADD  CONSTRAINT [FK__menus__log_id__534D60F1] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[menus] CHECK CONSTRAINT [FK__menus__log_id__534D60F1]
GO
ALTER TABLE [dbo].[options]  WITH CHECK ADD  CONSTRAINT [FK__options__log_id__5629CD9C] FOREIGN KEY([log_id])
REFERENCES [dbo].[login] ([log_id])
GO
ALTER TABLE [dbo].[options] CHECK CONSTRAINT [FK__options__log_id__5629CD9C]
GO
ALTER TABLE [dbo].[options]  WITH CHECK ADD  CONSTRAINT [FK__options__men_id__571DF1D5] FOREIGN KEY([men_id])
REFERENCES [dbo].[menus] ([men_id])
GO
ALTER TABLE [dbo].[options] CHECK CONSTRAINT [FK__options__men_id__571DF1D5]
GO
