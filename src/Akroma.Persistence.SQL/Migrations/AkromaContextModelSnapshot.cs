﻿// <auto-generated />
using Akroma.Persistence.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Akroma.Persistence.SQL.Migrations
{
    [DbContext(typeof(AkromaContext))]
    partial class AkromaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.BlockEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Difficulty");

                    b.Property<string>("ExtraData");

                    b.Property<long>("GasLimit");

                    b.Property<long>("GasUsed");

                    b.Property<string>("Hash");

                    b.Property<string>("LogsBloom");

                    b.Property<string>("Miner");

                    b.Property<string>("Nonce");

                    b.Property<int>("Number");

                    b.Property<string>("ParentHash");

                    b.Property<string>("Sha3Uncles");

                    b.Property<long>("Size");

                    b.Property<string>("StateRoot");

                    b.Property<long>("Timestamp");

                    b.Property<string>("TotalDifficulty");

                    b.Property<string>("TransactionsRoot");

                    b.HasKey("Id");

                    b.HasIndex("Miner");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.NetworkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Difficulty");

                    b.Property<string>("HashRate");

                    b.Property<int>("Height");

                    b.HasKey("Id");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.PriceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.Property<string>("Usd");

                    b.Property<decimal>("UsdDayAgoRaw");

                    b.Property<decimal>("UsdRaw");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Symbol");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlockHash");

                    b.Property<int>("BlockNumber");

                    b.Property<string>("From");

                    b.Property<string>("Gas");

                    b.Property<string>("GasPrice");

                    b.Property<string>("Hash")
                        .HasMaxLength(200);

                    b.Property<string>("Input");

                    b.Property<string>("Nonce");

                    b.Property<long>("Timestamp");

                    b.Property<string>("To");

                    b.Property<int>("TransactionIndex");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(38,18)");

                    b.HasKey("Id");

                    b.HasIndex("BlockHash");

                    b.HasIndex("From");

                    b.HasIndex("To");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.UncleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlockId");

                    b.Property<string>("Data");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("UncleEntity");
                });

            modelBuilder.Entity("Akroma.Persistence.SQL.Model.UncleEntity", b =>
                {
                    b.HasOne("Akroma.Persistence.SQL.Model.BlockEntity", "Block")
                        .WithMany("Uncles")
                        .HasForeignKey("BlockId");
                });
#pragma warning restore 612, 618
        }
    }
}
