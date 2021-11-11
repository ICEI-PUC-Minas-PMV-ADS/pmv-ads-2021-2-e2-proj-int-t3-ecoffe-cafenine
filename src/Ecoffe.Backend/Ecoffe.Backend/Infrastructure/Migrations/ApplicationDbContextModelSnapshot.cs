﻿// <auto-generated />
using System;
using Ecoffe.Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecoffe.Backend.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecoffe.Backend.Models.Cartao", b =>
                {
                    b.Property<int>("Id_Catao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dt_Validade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nm_Cartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr_Cartao")
                        .HasColumnType("int");

                    b.Property<string>("Tx_Bandeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Catao");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Cupom", b =>
                {
                    b.Property<int>("Id_Cupom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tx_Cupom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Vl_Cupom")
                        .HasColumnType("real");

                    b.HasKey("Id_Cupom");

                    b.ToTable("Cupom");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.EtapaVenda", b =>
                {
                    b.Property<int>("Id_Etapa_Venda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tx_Nome_Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Etapa_Venda");

                    b.ToTable("EtapaVenda");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Frete", b =>
                {
                    b.Property<int>("Id_Frete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Status_Frete")
                        .HasColumnType("int");

                    b.Property<string>("Nm_Status_Frete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Vl_Frete")
                        .HasColumnType("real");

                    b.HasKey("Id_Frete");

                    b.ToTable("Frete");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.NotaFiscal", b =>
                {
                    b.Property<int>("Id_NotaFiscal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NR_NOTA_FISCAL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XML")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_NotaFiscal");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Pedido", b =>
                {
                    b.Property<int>("Id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CupomId_Cupom")
                        .HasColumnType("int");

                    b.Property<DateTime>("DT_Pedido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataConfirmacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FreteId_Frete")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Cupom")
                        .HasColumnType("int");

                    b.Property<int>("Id_Frete")
                        .HasColumnType("int");

                    b.Property<int>("Id_NotaFiscal")
                        .HasColumnType("int");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int");

                    b.Property<int?>("NotaFiscalId_NotaFiscal")
                        .HasColumnType("int");

                    b.Property<decimal>("PesoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id_Pedido");

                    b.HasIndex("CupomId_Cupom");

                    b.HasIndex("FreteId_Frete");

                    b.HasIndex("NotaFiscalId_NotaFiscal");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Produto", b =>
                {
                    b.Property<int>("Id_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nm_Produto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nr_Altura")
                        .HasColumnType("real");

                    b.Property<float>("Nr_Largura")
                        .HasColumnType("real");

                    b.Property<float>("Nr_Peso_Liquido")
                        .HasColumnType("real");

                    b.Property<int?>("PedidoId_Pedido")
                        .HasColumnType("int");

                    b.Property<string>("Tx_Informacao_Comercial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Vl_Preco_Produto")
                        .HasColumnType("real");

                    b.HasKey("Id_Produto");

                    b.HasIndex("PedidoId_Pedido");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Seguranca", b =>
                {
                    b.Property<int>("Id_Cod_Seguranca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod_Seguranca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Cod_Seguranca");

                    b.ToTable("Seguranca");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Pedido", b =>
                {
                    b.HasOne("Ecoffe.Backend.Models.Cupom", "Cupom")
                        .WithMany()
                        .HasForeignKey("CupomId_Cupom");

                    b.HasOne("Ecoffe.Backend.Models.Frete", "Frete")
                        .WithMany()
                        .HasForeignKey("FreteId_Frete");

                    b.HasOne("Ecoffe.Backend.Models.NotaFiscal", "NotaFiscal")
                        .WithMany()
                        .HasForeignKey("NotaFiscalId_NotaFiscal");

                    b.HasOne("Ecoffe.Backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Cupom");

                    b.Navigation("Frete");

                    b.Navigation("NotaFiscal");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Produto", b =>
                {
                    b.HasOne("Ecoffe.Backend.Models.Pedido", null)
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId_Pedido");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Usuario", b =>
                {
                    b.HasOne("Ecoffe.Backend.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Ecoffe.Backend.Models.Pedido", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
