--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5 (Debian 14.5-1.pgdg110+1)
-- Dumped by pg_dump version 14.5

-- Started on 2022-12-09 19:41:34 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 216 (class 1259 OID 16723)
-- Name: alcance; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.alcance (
    idalcance integer NOT NULL,
    nombrealcance character varying(50) NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL,
    "isBiocombustible" boolean DEFAULT false NOT NULL
);


--
-- TOC entry 215 (class 1259 OID 16722)
-- Name: alcance_idalcance_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.alcance_idalcance_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3563 (class 0 OID 0)
-- Dependencies: 215
-- Name: alcance_idalcance_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.alcance_idalcance_seq OWNED BY public.alcance.idalcance;


--
-- TOC entry 218 (class 1259 OID 16735)
-- Name: categoria; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.categoria (
    idcategoria integer NOT NULL,
    nombrecategoria character varying(100) NOT NULL,
    idalcance integer NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 217 (class 1259 OID 16734)
-- Name: categoria_idcategoria_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.categoria_idcategoria_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3564 (class 0 OID 0)
-- Dependencies: 217
-- Name: categoria_idcategoria_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.categoria_idcategoria_seq OWNED BY public.categoria.idcategoria;


--
-- TOC entry 232 (class 1259 OID 16820)
-- Name: combustible; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.combustible (
    idcombustible integer NOT NULL,
    nombrecombustible character varying(50) NOT NULL,
    idunidad integer NOT NULL,
    idtipo integer NOT NULL,
    idactividad integer NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 231 (class 1259 OID 16819)
-- Name: combustible_idcombustible_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.combustible_idcombustible_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3565 (class 0 OID 0)
-- Dependencies: 231
-- Name: combustible_idcombustible_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.combustible_idcombustible_seq OWNED BY public.combustible.idcombustible;


--
-- TOC entry 234 (class 1259 OID 16865)
-- Name: configuracionactividad; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.configuracionactividad (
    idconfiguracion integer NOT NULL,
    idcombustible integer NOT NULL,
    idsubcategoria integer NOT NULL,
    idfuenteemision integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL,
    biocombustible boolean DEFAULT false NOT NULL,
    porcentaje numeric(10,4),
    idconfdependiente integer
);


--
-- TOC entry 233 (class 1259 OID 16864)
-- Name: configuracionactividad_idconfiguracion_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.configuracionactividad_idconfiguracion_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3566 (class 0 OID 0)
-- Dependencies: 233
-- Name: configuracionactividad_idconfiguracion_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.configuracionactividad_idconfiguracion_seq OWNED BY public.configuracionactividad.idconfiguracion;


--
-- TOC entry 247 (class 1259 OID 16990)
-- Name: departamento; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.departamento (
    codigodepartamento integer NOT NULL,
    nombredepartamento character varying(100) NOT NULL
);


--
-- TOC entry 246 (class 1259 OID 16974)
-- Name: emision; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.emision (
    idemision integer NOT NULL,
    mes1 numeric(20,10),
    mes2 numeric(20,10),
    mes3 numeric(20,10),
    mes4 numeric(20,10),
    mes5 numeric(20,10),
    mes6 numeric(20,10),
    mes7 numeric(20,10),
    mes8 numeric(20,10),
    mes9 numeric(20,10),
    mes10 numeric(20,10),
    mes11 numeric(20,10),
    mes12 numeric(20,10),
    valoranual numeric(20,10) NOT NULL,
    nodatos integer NOT NULL,
    promedio numeric(20,10) NOT NULL,
    desviacionestandar numeric(20,10) NOT NULL,
    coeficientevariacion numeric(20,10) NOT NULL,
    factort numeric(20,10) NOT NULL,
    incertidumbre numeric(20,10) NOT NULL,
    emisiontotal numeric(20,10) NOT NULL,
    idregistroanual integer NOT NULL,
    idconfiguracion integer NOT NULL
);


--
-- TOC entry 245 (class 1259 OID 16973)
-- Name: emision_idemision_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.emision_idemision_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3567 (class 0 OID 0)
-- Dependencies: 245
-- Name: emision_idemision_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.emision_idemision_seq OWNED BY public.emision.idemision;


--
-- TOC entry 242 (class 1259 OID 16948)
-- Name: emisiongei; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.emisiongei (
    idemisiongei integer NOT NULL,
    emisiongei numeric(10,3) NOT NULL,
    emisiongeiequivalente numeric(10,3) NOT NULL,
    "factorEmision" numeric(10,3) NOT NULL,
    potencialcalentamientoglobal numeric(10,3) NOT NULL,
    idfe integer NOT NULL,
    idregistroanual integer NOT NULL
);


--
-- TOC entry 241 (class 1259 OID 16947)
-- Name: emisiongei_idemisiongei_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.emisiongei_idemisiongei_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3568 (class 0 OID 0)
-- Dependencies: 241
-- Name: emisiongei_idemisiongei_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.emisiongei_idemisiongei_seq OWNED BY public.emisiongei.idemisiongei;


--
-- TOC entry 238 (class 1259 OID 16909)
-- Name: factoremision; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.factoremision (
    idfe integer NOT NULL,
    factoremision numeric(14,8) NOT NULL,
    potencialcalentamientoglobal numeric(14,8) NOT NULL,
    incertidumbremas numeric(7,3) DEFAULT 0,
    incertidumbremenos numeric(7,3) DEFAULT 0,
    idgei integer NOT NULL,
    idusuario integer NOT NULL,
    idconfiguracion integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 237 (class 1259 OID 16908)
-- Name: factoremision_idfe_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.factoremision_idfe_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3569 (class 0 OID 0)
-- Dependencies: 237
-- Name: factoremision_idfe_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.factoremision_idfe_seq OWNED BY public.factoremision.idfe;


--
-- TOC entry 222 (class 1259 OID 16769)
-- Name: fuenteemision; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.fuenteemision (
    idfuenteemision integer NOT NULL,
    nombrefuenteemision character varying(50) NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 221 (class 1259 OID 16768)
-- Name: fuenteemision_ifduenteemision_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.fuenteemision_ifduenteemision_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3570 (class 0 OID 0)
-- Dependencies: 221
-- Name: fuenteemision_ifduenteemision_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.fuenteemision_ifduenteemision_seq OWNED BY public.fuenteemision.idfuenteemision;


--
-- TOC entry 230 (class 1259 OID 16808)
-- Name: gei; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.gei (
    idgei integer NOT NULL,
    nombregei character varying(50) NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 229 (class 1259 OID 16807)
-- Name: gei_idgei_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.gei_idgei_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3571 (class 0 OID 0)
-- Dependencies: 229
-- Name: gei_idgei_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.gei_idgei_seq OWNED BY public.gei.idgei;


--
-- TOC entry 244 (class 1259 OID 16960)
-- Name: log; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.log (
    idlog bigint NOT NULL,
    accion integer NOT NULL,
    contenido text NOT NULL,
    fechaaccion timestamp without time zone NOT NULL,
    idusuario integer NOT NULL
);


--
-- TOC entry 243 (class 1259 OID 16959)
-- Name: log_idlog_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.log_idlog_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3572 (class 0 OID 0)
-- Dependencies: 243
-- Name: log_idlog_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.log_idlog_seq OWNED BY public.log.idlog;


--
-- TOC entry 248 (class 1259 OID 16995)
-- Name: municipio; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.municipio (
    codigomunicipio integer NOT NULL,
    nombremunicipio character varying(100) NOT NULL,
    codigodepartamento integer NOT NULL
);


--
-- TOC entry 236 (class 1259 OID 16887)
-- Name: registroactividad; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.registroactividad (
    idregistroactividad integer NOT NULL,
    valor numeric(10,3) NOT NULL,
    mes integer NOT NULL,
    "año" integer NOT NULL,
    idconfiguracion integer NOT NULL,
    idusuario integer NOT NULL,
    idsede integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 235 (class 1259 OID 16886)
-- Name: registroactividad_idregistroactividad_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.registroactividad_idregistroactividad_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3573 (class 0 OID 0)
-- Dependencies: 235
-- Name: registroactividad_idregistroactividad_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.registroactividad_idregistroactividad_seq OWNED BY public.registroactividad.idregistroactividad;


--
-- TOC entry 240 (class 1259 OID 16931)
-- Name: registroanual; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.registroanual (
    idregistroanual integer NOT NULL,
    fecharegistro timestamp with time zone NOT NULL,
    idsede integer NOT NULL,
    idusuario integer NOT NULL,
    "año" integer NOT NULL,
    estado boolean NOT NULL
);


--
-- TOC entry 239 (class 1259 OID 16930)
-- Name: registroanual_idregistroanual_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.registroanual_idregistroanual_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3574 (class 0 OID 0)
-- Dependencies: 239
-- Name: registroanual_idregistroanual_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.registroanual_idregistroanual_seq OWNED BY public.registroanual.idregistroanual;


--
-- TOC entry 250 (class 1259 OID 98942)
-- Name: reporte; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.reporte (
    idreporte integer NOT NULL,
    nombrereporte character varying(100) NOT NULL,
    link character varying(200) NOT NULL
);


--
-- TOC entry 249 (class 1259 OID 98941)
-- Name: reportes_idreportes_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.reportes_idreportes_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3575 (class 0 OID 0)
-- Dependencies: 249
-- Name: reportes_idreportes_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.reportes_idreportes_seq OWNED BY public.reporte.idreporte;


--
-- TOC entry 210 (class 1259 OID 16678)
-- Name: rol; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.rol (
    idrol integer NOT NULL,
    rol character varying(50) NOT NULL,
    "moduloRol" boolean DEFAULT false NOT NULL,
    "moduloSede" boolean DEFAULT false NOT NULL,
    "moduloConfiguracion" boolean DEFAULT false NOT NULL,
    "moduloRegistro" boolean DEFAULT false NOT NULL,
    "moduloVisualizacion" boolean DEFAULT false NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 209 (class 1259 OID 16677)
-- Name: rol_idrol_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.rol_idrol_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3576 (class 0 OID 0)
-- Dependencies: 209
-- Name: rol_idrol_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.rol_idrol_seq OWNED BY public.rol.idrol;


--
-- TOC entry 214 (class 1259 OID 16711)
-- Name: sede; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.sede (
    idsede integer NOT NULL,
    nombresede character varying(100) NOT NULL,
    direccion character varying(50) NOT NULL,
    idusuario integer NOT NULL,
    codigomunicipio integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 213 (class 1259 OID 16710)
-- Name: sede_idsede_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.sede_idsede_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3577 (class 0 OID 0)
-- Dependencies: 213
-- Name: sede_idsede_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.sede_idsede_seq OWNED BY public.sede.idsede;


--
-- TOC entry 220 (class 1259 OID 16752)
-- Name: subcategoria; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.subcategoria (
    idsubcategoria integer NOT NULL,
    nombresubcategoria character varying(150) NOT NULL,
    idcategoria integer NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 219 (class 1259 OID 16751)
-- Name: subcategoria_idsubcategoria_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.subcategoria_idsubcategoria_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3578 (class 0 OID 0)
-- Dependencies: 219
-- Name: subcategoria_idsubcategoria_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.subcategoria_idsubcategoria_seq OWNED BY public.subcategoria.idsubcategoria;


--
-- TOC entry 228 (class 1259 OID 16800)
-- Name: tipo; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.tipo (
    idtipo integer NOT NULL,
    tipo character varying(50) NOT NULL
);


--
-- TOC entry 227 (class 1259 OID 16799)
-- Name: tipo_idtipo_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.tipo_idtipo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3579 (class 0 OID 0)
-- Dependencies: 227
-- Name: tipo_idtipo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.tipo_idtipo_seq OWNED BY public.tipo.idtipo;


--
-- TOC entry 224 (class 1259 OID 16781)
-- Name: tipoactividad; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.tipoactividad (
    idtipoactividad integer NOT NULL,
    nombretipoactividad character varying(50) NOT NULL,
    idusuario integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 223 (class 1259 OID 16780)
-- Name: tipoactividad_idtipoactividad_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.tipoactividad_idtipoactividad_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3580 (class 0 OID 0)
-- Dependencies: 223
-- Name: tipoactividad_idtipoactividad_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.tipoactividad_idtipoactividad_seq OWNED BY public.tipoactividad.idtipoactividad;


--
-- TOC entry 226 (class 1259 OID 16793)
-- Name: unidad; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.unidad (
    idunidad integer NOT NULL,
    unidad character varying(50) NOT NULL
);


--
-- TOC entry 225 (class 1259 OID 16792)
-- Name: unidad_idunidad_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.unidad_idunidad_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3581 (class 0 OID 0)
-- Dependencies: 225
-- Name: unidad_idunidad_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.unidad_idunidad_seq OWNED BY public.unidad.idunidad;


--
-- TOC entry 212 (class 1259 OID 16699)
-- Name: usuario; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.usuario (
    idusuario integer NOT NULL,
    email character varying(50) NOT NULL,
    idrol integer NOT NULL,
    enabled boolean DEFAULT true NOT NULL
);


--
-- TOC entry 211 (class 1259 OID 16698)
-- Name: usuario_idusuario_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.usuario_idusuario_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3582 (class 0 OID 0)
-- Dependencies: 211
-- Name: usuario_idusuario_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.usuario_idusuario_seq OWNED BY public.usuario.idusuario;


--
-- TOC entry 251 (class 1259 OID 115325)
-- Name: vw_alcances; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_alcances AS
 SELECT a.idalcance,
    a.nombrealcance,
    c.idcategoria,
    c.nombrecategoria,
    s.idsubcategoria,
    s.nombresubcategoria
   FROM ((public.alcance a
     JOIN public.categoria c ON ((c.idalcance = a.idalcance)))
     JOIN public.subcategoria s ON ((s.idcategoria = c.idcategoria)));


--
-- TOC entry 252 (class 1259 OID 115329)
-- Name: vw_configuraciones; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_configuraciones AS
 SELECT c.idconfiguracion,
    a.idalcance,
    a.nombrealcance,
    a.idcategoria,
    a.nombrecategoria,
    a.idsubcategoria,
    a.nombresubcategoria,
    co.idcombustible,
    co.nombrecombustible
   FROM ((public.configuracionactividad c
     JOIN public.vw_alcances a ON ((c.idsubcategoria = a.idsubcategoria)))
     JOIN public.combustible co ON ((c.idcombustible = co.idcombustible)));


--
-- TOC entry 256 (class 1259 OID 156307)
-- Name: vw_datos; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_datos AS
 SELECT conf.idconfiguracion,
    conf.idalcance,
    conf.nombrealcance,
    conf.idcategoria,
    conf.nombrecategoria,
    conf.idsubcategoria,
    conf.nombresubcategoria,
    conf.idcombustible,
    conf.nombrecombustible,
    ract.idregistroactividad,
    ract."año" AS "regActi año",
    s.idsede,
    s.nombresede,
    ran.idregistroanual,
    ran."año" AS "regAnual año",
    ran.estado
   FROM (((public.vw_configuraciones conf
     LEFT JOIN public.registroactividad ract ON ((ract.idconfiguracion = conf.idconfiguracion)))
     LEFT JOIN public.sede s ON ((s.idsede = ract.idsede)))
     LEFT JOIN public.registroanual ran ON (((ran.idsede = s.idsede) AND (ran."año" = ract."año"))));


--
-- TOC entry 253 (class 1259 OID 131858)
-- Name: vw_emisiones_final; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_emisiones_final AS
 SELECT c.idconfiguracion,
    c.idalcance,
    c.nombrealcance,
    c.idcategoria,
    c.nombrecategoria,
    c.idsubcategoria,
    c.nombresubcategoria,
    c.idcombustible,
    c.nombrecombustible,
    ra."año",
    ra.idsede,
    e.emisiontotal,
    s.nombresede,
    e.incertidumbre
   FROM (((public.registroanual ra
     JOIN public.emision e ON ((e.idregistroanual = ra.idregistroanual)))
     JOIN public.vw_configuraciones c ON ((e.idconfiguracion = c.idconfiguracion)))
     JOIN public.sede s ON ((s.idsede = ra.idsede)))
  WHERE (ra.estado = true);


--
-- TOC entry 254 (class 1259 OID 139901)
-- Name: vw_emisionesgei_final; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_emisionesgei_final AS
 SELECT c.idconfiguracion,
    c.idalcance,
    c.nombrealcance,
    c.idcategoria,
    c.nombrecategoria,
    c.idsubcategoria,
    c.nombresubcategoria,
    c.idcombustible,
    c.nombrecombustible,
    ra."año",
    ra.idsede,
    s.nombresede,
    g.idgei,
    g.nombregei,
    eg.emisiongeiequivalente
   FROM (((((public.emisiongei eg
     JOIN public.registroanual ra ON ((eg.idregistroanual = ra.idregistroanual)))
     JOIN public.factoremision fe ON ((eg.idfe = fe.idfe)))
     JOIN public.vw_configuraciones c ON ((fe.idconfiguracion = c.idconfiguracion)))
     JOIN public.gei g ON ((g.idgei = fe.idgei)))
     JOIN public.sede s ON ((s.idsede = ra.idsede)))
  WHERE (ra.estado = true);


--
-- TOC entry 255 (class 1259 OID 148093)
-- Name: vw_logs; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.vw_logs AS
 SELECT l.idlog,
    l.accion,
    l.contenido,
    l.fechaaccion,
    l.idusuario,
    u.email
   FROM (public.log l
     JOIN public.usuario u ON ((l.idusuario = u.idusuario)));


--
-- TOC entry 3305 (class 2604 OID 16726)
-- Name: alcance idalcance; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.alcance ALTER COLUMN idalcance SET DEFAULT nextval('public.alcance_idalcance_seq'::regclass);


--
-- TOC entry 3308 (class 2604 OID 16738)
-- Name: categoria idcategoria; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.categoria ALTER COLUMN idcategoria SET DEFAULT nextval('public.categoria_idcategoria_seq'::regclass);


--
-- TOC entry 3320 (class 2604 OID 16823)
-- Name: combustible idcombustible; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible ALTER COLUMN idcombustible SET DEFAULT nextval('public.combustible_idcombustible_seq'::regclass);


--
-- TOC entry 3322 (class 2604 OID 16868)
-- Name: configuracionactividad idconfiguracion; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad ALTER COLUMN idconfiguracion SET DEFAULT nextval('public.configuracionactividad_idconfiguracion_seq'::regclass);


--
-- TOC entry 3334 (class 2604 OID 16977)
-- Name: emision idemision; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emision ALTER COLUMN idemision SET DEFAULT nextval('public.emision_idemision_seq'::regclass);


--
-- TOC entry 3332 (class 2604 OID 16951)
-- Name: emisiongei idemisiongei; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emisiongei ALTER COLUMN idemisiongei SET DEFAULT nextval('public.emisiongei_idemisiongei_seq'::regclass);


--
-- TOC entry 3327 (class 2604 OID 16912)
-- Name: factoremision idfe; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.factoremision ALTER COLUMN idfe SET DEFAULT nextval('public.factoremision_idfe_seq'::regclass);


--
-- TOC entry 3312 (class 2604 OID 16772)
-- Name: fuenteemision idfuenteemision; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.fuenteemision ALTER COLUMN idfuenteemision SET DEFAULT nextval('public.fuenteemision_ifduenteemision_seq'::regclass);


--
-- TOC entry 3318 (class 2604 OID 16811)
-- Name: gei idgei; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.gei ALTER COLUMN idgei SET DEFAULT nextval('public.gei_idgei_seq'::regclass);


--
-- TOC entry 3333 (class 2604 OID 57981)
-- Name: log idlog; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.log ALTER COLUMN idlog SET DEFAULT nextval('public.log_idlog_seq'::regclass);


--
-- TOC entry 3325 (class 2604 OID 16890)
-- Name: registroactividad idregistroactividad; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroactividad ALTER COLUMN idregistroactividad SET DEFAULT nextval('public.registroactividad_idregistroactividad_seq'::regclass);


--
-- TOC entry 3331 (class 2604 OID 16934)
-- Name: registroanual idregistroanual; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroanual ALTER COLUMN idregistroanual SET DEFAULT nextval('public.registroanual_idregistroanual_seq'::regclass);


--
-- TOC entry 3335 (class 2604 OID 98945)
-- Name: reporte idreporte; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reporte ALTER COLUMN idreporte SET DEFAULT nextval('public.reportes_idreportes_seq'::regclass);


--
-- TOC entry 3294 (class 2604 OID 16681)
-- Name: rol idrol; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.rol ALTER COLUMN idrol SET DEFAULT nextval('public.rol_idrol_seq'::regclass);


--
-- TOC entry 3303 (class 2604 OID 16714)
-- Name: sede idsede; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sede ALTER COLUMN idsede SET DEFAULT nextval('public.sede_idsede_seq'::regclass);


--
-- TOC entry 3310 (class 2604 OID 16755)
-- Name: subcategoria idsubcategoria; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.subcategoria ALTER COLUMN idsubcategoria SET DEFAULT nextval('public.subcategoria_idsubcategoria_seq'::regclass);


--
-- TOC entry 3317 (class 2604 OID 16803)
-- Name: tipo idtipo; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tipo ALTER COLUMN idtipo SET DEFAULT nextval('public.tipo_idtipo_seq'::regclass);


--
-- TOC entry 3314 (class 2604 OID 16784)
-- Name: tipoactividad idtipoactividad; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tipoactividad ALTER COLUMN idtipoactividad SET DEFAULT nextval('public.tipoactividad_idtipoactividad_seq'::regclass);


--
-- TOC entry 3316 (class 2604 OID 16796)
-- Name: unidad idunidad; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.unidad ALTER COLUMN idunidad SET DEFAULT nextval('public.unidad_idunidad_seq'::regclass);


--
-- TOC entry 3301 (class 2604 OID 16702)
-- Name: usuario idusuario; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuario ALTER COLUMN idusuario SET DEFAULT nextval('public.usuario_idusuario_seq'::regclass);


--
-- TOC entry 3343 (class 2606 OID 16728)
-- Name: alcance alcance_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.alcance
    ADD CONSTRAINT alcance_pkey PRIMARY KEY (idalcance);


--
-- TOC entry 3345 (class 2606 OID 16740)
-- Name: categoria categoria_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.categoria
    ADD CONSTRAINT categoria_pkey PRIMARY KEY (idcategoria);


--
-- TOC entry 3359 (class 2606 OID 16825)
-- Name: combustible combustible_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible
    ADD CONSTRAINT combustible_pkey PRIMARY KEY (idcombustible);


--
-- TOC entry 3361 (class 2606 OID 16870)
-- Name: configuracionactividad configuracionactividad_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad
    ADD CONSTRAINT configuracionactividad_pkey PRIMARY KEY (idconfiguracion);


--
-- TOC entry 3375 (class 2606 OID 16994)
-- Name: departamento departamento_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.departamento
    ADD CONSTRAINT departamento_pkey PRIMARY KEY (codigodepartamento);


--
-- TOC entry 3373 (class 2606 OID 16979)
-- Name: emision emision_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emision
    ADD CONSTRAINT emision_pkey PRIMARY KEY (idemision);


--
-- TOC entry 3369 (class 2606 OID 16953)
-- Name: emisiongei emisiongei_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emisiongei
    ADD CONSTRAINT emisiongei_pkey PRIMARY KEY (idemisiongei);


--
-- TOC entry 3365 (class 2606 OID 16914)
-- Name: factoremision factoremision_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.factoremision
    ADD CONSTRAINT factoremision_pkey PRIMARY KEY (idfe);


--
-- TOC entry 3349 (class 2606 OID 16774)
-- Name: fuenteemision fuenteemision_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.fuenteemision
    ADD CONSTRAINT fuenteemision_pkey PRIMARY KEY (idfuenteemision);


--
-- TOC entry 3357 (class 2606 OID 16813)
-- Name: gei gei_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.gei
    ADD CONSTRAINT gei_pkey PRIMARY KEY (idgei);


--
-- TOC entry 3371 (class 2606 OID 57983)
-- Name: log log_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.log
    ADD CONSTRAINT log_pkey PRIMARY KEY (idlog);


--
-- TOC entry 3377 (class 2606 OID 16999)
-- Name: municipio municipio_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.municipio
    ADD CONSTRAINT municipio_pkey PRIMARY KEY (codigomunicipio);


--
-- TOC entry 3363 (class 2606 OID 16892)
-- Name: registroactividad registroactividad_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroactividad
    ADD CONSTRAINT registroactividad_pkey PRIMARY KEY (idregistroactividad);


--
-- TOC entry 3367 (class 2606 OID 16936)
-- Name: registroanual registroanual_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroanual
    ADD CONSTRAINT registroanual_pkey PRIMARY KEY (idregistroanual);


--
-- TOC entry 3379 (class 2606 OID 98947)
-- Name: reporte reportes_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reporte
    ADD CONSTRAINT reportes_pkey PRIMARY KEY (idreporte);


--
-- TOC entry 3337 (class 2606 OID 16683)
-- Name: rol rol_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.rol
    ADD CONSTRAINT rol_pkey PRIMARY KEY (idrol);


--
-- TOC entry 3341 (class 2606 OID 16716)
-- Name: sede sede_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sede
    ADD CONSTRAINT sede_pkey PRIMARY KEY (idsede);


--
-- TOC entry 3347 (class 2606 OID 16757)
-- Name: subcategoria subcategoria_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.subcategoria
    ADD CONSTRAINT subcategoria_pkey PRIMARY KEY (idsubcategoria);


--
-- TOC entry 3355 (class 2606 OID 16805)
-- Name: tipo tipo_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tipo
    ADD CONSTRAINT tipo_pkey PRIMARY KEY (idtipo);


--
-- TOC entry 3351 (class 2606 OID 16786)
-- Name: tipoactividad tipoactividad_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tipoactividad
    ADD CONSTRAINT tipoactividad_pkey PRIMARY KEY (idtipoactividad);


--
-- TOC entry 3353 (class 2606 OID 16798)
-- Name: unidad unidad_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.unidad
    ADD CONSTRAINT unidad_pkey PRIMARY KEY (idunidad);


--
-- TOC entry 3339 (class 2606 OID 16704)
-- Name: usuario usuario_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (idusuario);


--
-- TOC entry 3383 (class 2606 OID 16729)
-- Name: alcance alcance_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.alcance
    ADD CONSTRAINT alcance_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3384 (class 2606 OID 16741)
-- Name: categoria categoria_idalcance_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.categoria
    ADD CONSTRAINT categoria_idalcance_fkey FOREIGN KEY (idalcance) REFERENCES public.alcance(idalcance);


--
-- TOC entry 3385 (class 2606 OID 16746)
-- Name: categoria categoria_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.categoria
    ADD CONSTRAINT categoria_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3393 (class 2606 OID 16836)
-- Name: combustible combustible_idactividad_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible
    ADD CONSTRAINT combustible_idactividad_fkey FOREIGN KEY (idactividad) REFERENCES public.tipoactividad(idtipoactividad);


--
-- TOC entry 3392 (class 2606 OID 16831)
-- Name: combustible combustible_idtipo_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible
    ADD CONSTRAINT combustible_idtipo_fkey FOREIGN KEY (idtipo) REFERENCES public.tipo(idtipo);


--
-- TOC entry 3391 (class 2606 OID 16826)
-- Name: combustible combustible_idunidad_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible
    ADD CONSTRAINT combustible_idunidad_fkey FOREIGN KEY (idunidad) REFERENCES public.unidad(idunidad);


--
-- TOC entry 3394 (class 2606 OID 16841)
-- Name: combustible combustible_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.combustible
    ADD CONSTRAINT combustible_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3395 (class 2606 OID 16871)
-- Name: configuracionactividad configuracionactividad_idcombustible_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad
    ADD CONSTRAINT configuracionactividad_idcombustible_fkey FOREIGN KEY (idcombustible) REFERENCES public.combustible(idcombustible);


--
-- TOC entry 3398 (class 2606 OID 123519)
-- Name: configuracionactividad configuracionactividad_idconfdependiente_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad
    ADD CONSTRAINT configuracionactividad_idconfdependiente_fkey FOREIGN KEY (idconfdependiente) REFERENCES public.configuracionactividad(idconfiguracion);


--
-- TOC entry 3397 (class 2606 OID 16881)
-- Name: configuracionactividad configuracionactividad_idfuenteemision_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad
    ADD CONSTRAINT configuracionactividad_idfuenteemision_fkey FOREIGN KEY (idfuenteemision) REFERENCES public.fuenteemision(idfuenteemision);


--
-- TOC entry 3396 (class 2606 OID 16876)
-- Name: configuracionactividad configuracionactividad_idsubcategoria_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.configuracionactividad
    ADD CONSTRAINT configuracionactividad_idsubcategoria_fkey FOREIGN KEY (idsubcategoria) REFERENCES public.subcategoria(idsubcategoria);


--
-- TOC entry 3410 (class 2606 OID 16985)
-- Name: emision emision_idconfiguracion_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emision
    ADD CONSTRAINT emision_idconfiguracion_fkey FOREIGN KEY (idconfiguracion) REFERENCES public.configuracionactividad(idconfiguracion);


--
-- TOC entry 3411 (class 2606 OID 16980)
-- Name: emision emision_idregistroanual_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emision
    ADD CONSTRAINT emision_idregistroanual_fkey FOREIGN KEY (idregistroanual) REFERENCES public.registroanual(idregistroanual);


--
-- TOC entry 3407 (class 2606 OID 17010)
-- Name: emisiongei emisiongei_idfe_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emisiongei
    ADD CONSTRAINT emisiongei_idfe_fkey FOREIGN KEY (idfe) REFERENCES public.factoremision(idfe);


--
-- TOC entry 3408 (class 2606 OID 66173)
-- Name: emisiongei emisiongei_idregistroanual_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.emisiongei
    ADD CONSTRAINT emisiongei_idregistroanual_fkey FOREIGN KEY (idregistroanual) REFERENCES public.registroanual(idregistroanual);


--
-- TOC entry 3402 (class 2606 OID 17015)
-- Name: factoremision factoremision_idconfiguracion_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.factoremision
    ADD CONSTRAINT factoremision_idconfiguracion_fkey FOREIGN KEY (idconfiguracion) REFERENCES public.configuracionactividad(idconfiguracion);


--
-- TOC entry 3403 (class 2606 OID 16925)
-- Name: factoremision factoremision_idgei_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.factoremision
    ADD CONSTRAINT factoremision_idgei_fkey FOREIGN KEY (idgei) REFERENCES public.gei(idgei);


--
-- TOC entry 3404 (class 2606 OID 16920)
-- Name: factoremision factoremision_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.factoremision
    ADD CONSTRAINT factoremision_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3388 (class 2606 OID 16775)
-- Name: fuenteemision fuenteemision_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.fuenteemision
    ADD CONSTRAINT fuenteemision_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3390 (class 2606 OID 16814)
-- Name: gei gei_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.gei
    ADD CONSTRAINT gei_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3409 (class 2606 OID 16968)
-- Name: log log_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.log
    ADD CONSTRAINT log_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3412 (class 2606 OID 17000)
-- Name: municipio municipio_codigodepartamento_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.municipio
    ADD CONSTRAINT municipio_codigodepartamento_fkey FOREIGN KEY (codigodepartamento) REFERENCES public.departamento(codigodepartamento);


--
-- TOC entry 3399 (class 2606 OID 16893)
-- Name: registroactividad registroactividad_idconfiguracion_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroactividad
    ADD CONSTRAINT registroactividad_idconfiguracion_fkey FOREIGN KEY (idconfiguracion) REFERENCES public.configuracionactividad(idconfiguracion);


--
-- TOC entry 3400 (class 2606 OID 16903)
-- Name: registroactividad registroactividad_idsede_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroactividad
    ADD CONSTRAINT registroactividad_idsede_fkey FOREIGN KEY (idsede) REFERENCES public.sede(idsede);


--
-- TOC entry 3401 (class 2606 OID 16898)
-- Name: registroactividad registroactividad_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroactividad
    ADD CONSTRAINT registroactividad_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3405 (class 2606 OID 16942)
-- Name: registroanual registroanual_idsede_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroanual
    ADD CONSTRAINT registroanual_idsede_fkey FOREIGN KEY (idsede) REFERENCES public.sede(idsede);


--
-- TOC entry 3406 (class 2606 OID 16937)
-- Name: registroanual registroanual_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.registroanual
    ADD CONSTRAINT registroanual_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3382 (class 2606 OID 17005)
-- Name: sede sede_codigomunicipio_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sede
    ADD CONSTRAINT sede_codigomunicipio_fkey FOREIGN KEY (codigomunicipio) REFERENCES public.municipio(codigomunicipio);


--
-- TOC entry 3381 (class 2606 OID 16717)
-- Name: sede sede_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sede
    ADD CONSTRAINT sede_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3386 (class 2606 OID 16758)
-- Name: subcategoria subcategoria_idcategoria_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.subcategoria
    ADD CONSTRAINT subcategoria_idcategoria_fkey FOREIGN KEY (idcategoria) REFERENCES public.categoria(idcategoria);


--
-- TOC entry 3387 (class 2606 OID 16763)
-- Name: subcategoria subcategoria_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.subcategoria
    ADD CONSTRAINT subcategoria_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3389 (class 2606 OID 16787)
-- Name: tipoactividad tipoactividad_idusuario_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tipoactividad
    ADD CONSTRAINT tipoactividad_idusuario_fkey FOREIGN KEY (idusuario) REFERENCES public.usuario(idusuario);


--
-- TOC entry 3380 (class 2606 OID 16705)
-- Name: usuario usuario_idrol_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_idrol_fkey FOREIGN KEY (idrol) REFERENCES public.rol(idrol);


-- Completed on 2022-12-09 19:41:35 UTC

--
-- PostgreSQL database dump complete
--

