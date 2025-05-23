PGDMP  .    "                }            postgres    17.4    17.4     0           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            1           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            2           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            3           1262    5    postgres    DATABASE     n   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'es-MX';
    DROP DATABASE postgres;
                     postgres    false            4           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                        postgres    false    4915            �            1259    16400    movimientos    TABLE     �  CREATE TABLE public.movimientos (
    id integer NOT NULL,
    producto_id integer NOT NULL,
    tipo_movimiento character varying(10) NOT NULL,
    cantidad integer NOT NULL,
    fecha timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT movimientos_cantidad_check CHECK ((cantidad > 0)),
    CONSTRAINT movimientos_tipo_movimiento_check CHECK (((tipo_movimiento)::text = ANY ((ARRAY['entrada'::character varying, 'salida'::character varying])::text[])))
);
    DROP TABLE public.movimientos;
       public         heap r       postgres    false            �            1259    16399    movimientos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.movimientos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.movimientos_id_seq;
       public               postgres    false    220            5           0    0    movimientos_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.movimientos_id_seq OWNED BY public.movimientos.id;
          public               postgres    false    219            �            1259    16389 	   productos    TABLE     �   CREATE TABLE public.productos (
    id integer NOT NULL,
    nombre character varying(255) NOT NULL,
    cantidad integer DEFAULT 0,
    CONSTRAINT productos_cantidad_check CHECK ((cantidad >= 0))
);
    DROP TABLE public.productos;
       public         heap r       postgres    false            �            1259    16388    productos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.productos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.productos_id_seq;
       public               postgres    false    218            6           0    0    productos_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.productos_id_seq OWNED BY public.productos.id;
          public               postgres    false    217            �           2604    16403    movimientos id    DEFAULT     p   ALTER TABLE ONLY public.movimientos ALTER COLUMN id SET DEFAULT nextval('public.movimientos_id_seq'::regclass);
 =   ALTER TABLE public.movimientos ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    220    219    220            �           2604    16392    productos id    DEFAULT     l   ALTER TABLE ONLY public.productos ALTER COLUMN id SET DEFAULT nextval('public.productos_id_seq'::regclass);
 ;   ALTER TABLE public.productos ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    218    217    218            -          0    16400    movimientos 
   TABLE DATA           X   COPY public.movimientos (id, producto_id, tipo_movimiento, cantidad, fecha) FROM stdin;
    public               postgres    false    220          +          0    16389 	   productos 
   TABLE DATA           9   COPY public.productos (id, nombre, cantidad) FROM stdin;
    public               postgres    false    218   #       7           0    0    movimientos_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.movimientos_id_seq', 1, false);
          public               postgres    false    219            8           0    0    productos_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.productos_id_seq', 1, true);
          public               postgres    false    217            �           2606    16408    movimientos movimientos_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.movimientos
    ADD CONSTRAINT movimientos_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.movimientos DROP CONSTRAINT movimientos_pkey;
       public                 postgres    false    220            �           2606    16398    productos productos_nombre_key 
   CONSTRAINT     [   ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_nombre_key UNIQUE (nombre);
 H   ALTER TABLE ONLY public.productos DROP CONSTRAINT productos_nombre_key;
       public                 postgres    false    218            �           2606    16396    productos productos_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.productos DROP CONSTRAINT productos_pkey;
       public                 postgres    false    218            �           2606    16409 (   movimientos movimientos_producto_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.movimientos
    ADD CONSTRAINT movimientos_producto_id_fkey FOREIGN KEY (producto_id) REFERENCES public.productos(id) ON DELETE CASCADE;
 R   ALTER TABLE ONLY public.movimientos DROP CONSTRAINT movimientos_producto_id_fkey;
       public               postgres    false    218    4757    220            -      x������ � �      +      x�3��I,(�/P��44������ 7�     