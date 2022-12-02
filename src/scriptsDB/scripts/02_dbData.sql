--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5 (Debian 14.5-1.pgdg110+1)
-- Dumped by pg_dump version 14.5

-- Started on 2022-12-01 19:37:05 UTC

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

--
-- TOC entry 3517 (class 0 OID 16678)
-- Dependencies: 210
-- Data for Name: rol; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.rol VALUES (6, 'AdmiUsuario', true, true, true, true, true, true);
INSERT INTO public.rol VALUES (1, 'Administrador de roles', true, false, false, false, false, true);
INSERT INTO public.rol VALUES (2, 'Administrador de sedes', false, true, false, false, false, true);
INSERT INTO public.rol VALUES (3, 'Administrador de configuraciones', false, false, true, false, false, true);
INSERT INTO public.rol VALUES (4, 'Registrador', false, false, false, true, false, true);
INSERT INTO public.rol VALUES (5, 'Visualizador', false, false, false, false, true, true);


--
-- TOC entry 3519 (class 0 OID 16699)
-- Dependencies: 212
-- Data for Name: usuario; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.usuario VALUES (6, 'admin', 6, true);


--
-- TOC entry 3523 (class 0 OID 16723)
-- Dependencies: 216
-- Data for Name: alcance; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.alcance VALUES (1, 'Alcance 1', 6, true, false);
INSERT INTO public.alcance VALUES (2, 'Alcance 2', 6, true, false);
INSERT INTO public.alcance VALUES (3, 'Alcance 3', 6, true, false);
INSERT INTO public.alcance VALUES (4, 'Biocombustibles', 6, true, true);


--
-- TOC entry 3525 (class 0 OID 16735)
-- Dependencies: 218
-- Data for Name: categoria; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.categoria VALUES (1, 'Emisiones Directas de Fuentes Fijas', 1, 6, true);
INSERT INTO public.categoria VALUES (2, 'Emisiones Directas de Fuentes Móviles', 1, 6, true);
INSERT INTO public.categoria VALUES (3, 'Emisiones Directas de Fuentes Fugitivas', 1, 6, true);
INSERT INTO public.categoria VALUES (4, 'Emisiones Indirectas de Fuentes Fijas', 2, 6, true);
INSERT INTO public.categoria VALUES (5, 'Emisiones Indirectas de Fuentes Moviles ', 3, 6, true);
INSERT INTO public.categoria VALUES (6, 'Emisiones Indirectas por Productos de la Organizacion', 3, 6, true);
INSERT INTO public.categoria VALUES (7, 'Emisiones Indirectas por Disposicion de Residuos', 3, 6, true);
INSERT INTO public.categoria VALUES (8, 'Emisiones Indirectas por Captacion y Vertimiento', 3, 6, true);
INSERT INTO public.categoria VALUES (9, 'Emisiones Indirectas de Biomasa', 4, 6, true);


--
-- TOC entry 3535 (class 0 OID 16800)
-- Dependencies: 228
-- Data for Name: tipo; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.tipo VALUES (1, 'Liquido');
INSERT INTO public.tipo VALUES (2, 'Gas');
INSERT INTO public.tipo VALUES (3, 'Energía');
INSERT INTO public.tipo VALUES (4, 'Solido');


--
-- TOC entry 3531 (class 0 OID 16781)
-- Dependencies: 224
-- Data for Name: tipoactividad; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.tipoactividad VALUES (1, 'Consumo de combustible', 6, true);
INSERT INTO public.tipoactividad VALUES (2, 'Consumo de lubricantes', 6, true);
INSERT INTO public.tipoactividad VALUES (3, 'Descarga de extintores', 6, true);
INSERT INTO public.tipoactividad VALUES (4, 'Consumo de refrigerantes', 6, true);
INSERT INTO public.tipoactividad VALUES (5, 'Consumo de energia electrica', 6, true);
INSERT INTO public.tipoactividad VALUES (6, 'Origen-Destino-Clase-Pasajeros', 6, true);
INSERT INTO public.tipoactividad VALUES (7, 'Distancia recorrida', 6, true);
INSERT INTO public.tipoactividad VALUES (8, 'Consumo de productos', 6, true);
INSERT INTO public.tipoactividad VALUES (9, 'Cantidad de residuos solidos', 6, true);
INSERT INTO public.tipoactividad VALUES (10, 'Cantidad de residuos peligrosos', 6, true);
INSERT INTO public.tipoactividad VALUES (11, 'Volumen de agua residual vertida', 6, true);
INSERT INTO public.tipoactividad VALUES (12, 'Volumen de agua potable', 6, true);


--
-- TOC entry 3533 (class 0 OID 16793)
-- Dependencies: 226
-- Data for Name: unidad; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.unidad VALUES (1, 'Gal');
INSERT INTO public.unidad VALUES (2, 'm3');
INSERT INTO public.unidad VALUES (3, 'Kg');
INSERT INTO public.unidad VALUES (4, 'Kg humedo');
INSERT INTO public.unidad VALUES (5, 'Km');
INSERT INTO public.unidad VALUES (6, 'Kg CO2');
INSERT INTO public.unidad VALUES (7, 'Kwh');


--
-- TOC entry 3539 (class 0 OID 16820)
-- Dependencies: 232
-- Data for Name: combustible; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.combustible VALUES (23, 'Electricidad', 7, 3, 5, 6, true);
INSERT INTO public.combustible VALUES (24, 'Jet A1 (supuesto)', 6, 1, 6, 6, true);
INSERT INTO public.combustible VALUES (25, 'Diésel o ACMP (sin mezcla biodiesel)', 5, 1, 7, 6, true);
INSERT INTO public.combustible VALUES (26, 'Gasolina Motor (sin mezcla bioetanol)', 5, 1, 7, 6, true);
INSERT INTO public.combustible VALUES (27, 'Diésel B10 (mezcla comercial)', 5, 1, 7, 6, true);
INSERT INTO public.combustible VALUES (28, 'Gasolina E10 (mezcla comercial)', 5, 1, 7, 6, true);
INSERT INTO public.combustible VALUES (29, 'Papel bond blanco', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (30, 'Tintas', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (31, 'Residuos solidos a relleno sanitario', 4, 4, 9, 6, true);
INSERT INTO public.combustible VALUES (32, 'Residuos solidos peligrosos', 3, 4, 10, 6, true);
INSERT INTO public.combustible VALUES (33, 'Vertimientos domesticos alcantarilla', 2, 1, 11, 6, true);
INSERT INTO public.combustible VALUES (34, 'Captacion de agua potable', 2, 1, 12, 6, true);
INSERT INTO public.combustible VALUES (35, 'Biodiesel palma', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (36, 'Bioetanol anhidro', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (37, 'Biogás genérico', 2, 2, 1, 6, true);
INSERT INTO public.combustible VALUES (38, 'CFC-11 / R-11', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (39, 'CFC-12/R-12', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (40, 'HCFC-141B/R-141B', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (41, 'HFC-23/R-23', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (42, 'HFC-143/R-143', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (43, 'R-422D', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (44, 'R-290', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (45, 'Halon-1301', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (46, 'Papel reciclado', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (47, 'Papel mate de revista', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (48, 'Papel brillante de revista', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (49, 'Polietileno de alta densidad', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (50, 'Polietileno de baja densidad', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (51, 'Polipropileno', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (52, 'Aluminio primario', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (53, 'Aluminio reciclado', 3, 4, 8, 6, true);
INSERT INTO public.combustible VALUES (54, 'Vertimientos domesticos PTAR', 2, 1, 11, 6, true);
INSERT INTO public.combustible VALUES (1, 'Diésel o ACMP (sin mezcla biodiesel)', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (2, 'Gasolina Motor (sin mezcla bioetanol)', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (3, 'Diésel B10 (mezcla comercial)', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (4, 'Gasolina E10 (mezcla comercial)', 1, 1, 1, 6, true);
INSERT INTO public.combustible VALUES (5, 'Gas natural génerico', 2, 2, 1, 6, true);
INSERT INTO public.combustible VALUES (6, 'Aceite lubricante', 1, 1, 2, 6, true);
INSERT INTO public.combustible VALUES (7, 'Grasa lubricante', 3, 1, 2, 6, true);
INSERT INTO public.combustible VALUES (8, 'Extintores CO2', 3, 2, 3, 6, true);
INSERT INTO public.combustible VALUES (9, 'Extintores R-123/HCFC-123', 3, 2, 3, 6, true);
INSERT INTO public.combustible VALUES (10, 'HFC-32 / R-32', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (11, 'HFC-125 / R-125', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (12, 'HFC-134a / R-134a', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (13, 'HFC-152a', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (14, 'HFC-143a / R-143a', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (15, 'HFC-227ea / FM-200', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (16, 'PFC', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (17, 'SF6', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (18, 'R-407C', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (19, 'R-410A', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (20, 'R-22 / HCFC-22', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (21, 'HFC-134 / R-134', 3, 2, 4, 6, true);
INSERT INTO public.combustible VALUES (22, 'R-404A', 3, 2, 4, 6, true);


--
-- TOC entry 3529 (class 0 OID 16769)
-- Dependencies: 222
-- Data for Name: fuenteemision; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.fuenteemision VALUES (1, 'Fija', 6, true);
INSERT INTO public.fuenteemision VALUES (2, 'Movil terrestre', 6, true);
INSERT INTO public.fuenteemision VALUES (3, 'Fugitiva', 6, true);
INSERT INTO public.fuenteemision VALUES (4, 'Movil aereo', 6, true);
INSERT INTO public.fuenteemision VALUES (5, 'Uso de productos', 6, true);
INSERT INTO public.fuenteemision VALUES (6, 'Disposicion de residuos solidos', 6, true);
INSERT INTO public.fuenteemision VALUES (7, 'Vertimiento de agua residual', 6, true);
INSERT INTO public.fuenteemision VALUES (8, 'Captacion de agua potable', 6, true);


--
-- TOC entry 3527 (class 0 OID 16752)
-- Dependencies: 220
-- Data for Name: subcategoria; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.subcategoria VALUES (1, 'Fuente fija para la autogeneración de energía', 1, 6, true);
INSERT INTO public.subcategoria VALUES (2, 'Fuente fija de energía para las instalaciones', 1, 6, true);
INSERT INTO public.subcategoria VALUES (3, 'Fuente movil que utiliza combustibles liquidos en vechiculos propios de la empresa', 2, 6, true);
INSERT INTO public.subcategoria VALUES (4, 'Fuente movil que utiliza combustibles gaseosos en vechiculos propios de la empresa', 2, 6, true);
INSERT INTO public.subcategoria VALUES (5, 'Fuente movil que utiliza lubricantes en vechiculos propios de la empresa', 2, 6, true);
INSERT INTO public.subcategoria VALUES (6, 'Emision fugitiva producto de la descarga de extintores', 3, 6, true);
INSERT INTO public.subcategoria VALUES (7, 'Emision fugitiva producto del escape de gases refrigerantes', 3, 6, true);
INSERT INTO public.subcategoria VALUES (8, 'Emision indirecta asociada al consumo de energia electrica de la red nacional', 4, 6, true);
INSERT INTO public.subcategoria VALUES (9, 'Emisiones asociadas a viajes aereos corporativos', 5, 6, true);
INSERT INTO public.subcategoria VALUES (10, 'Emisiones asociadas a viajes terrestres corporativos', 5, 6, true);
INSERT INTO public.subcategoria VALUES (11, 'Emisiones indirectas por consumo de materiales', 6, 6, true);
INSERT INTO public.subcategoria VALUES (12, 'Emisiones indirectas por disposicion de residuos solidos', 7, 6, true);
INSERT INTO public.subcategoria VALUES (13, 'Emisiones indirectas por captacion y vertimiento de agua residual', 8, 6, true);
INSERT INTO public.subcategoria VALUES (14, 'Emisiones indirectas por captacion y vertimiento de agua potable', 8, 6, true);
INSERT INTO public.subcategoria VALUES (15, 'Emisiones indirectas por consumo de biocombustibles en fuentes estacionarias', 9, 6, true);
INSERT INTO public.subcategoria VALUES (16, 'Emisiones indirectas por consumo de biocombustibles en fuentes moviles', 9, 6, true);


--
-- TOC entry 3541 (class 0 OID 16865)
-- Dependencies: 234
-- Data for Name: configuracionactividad; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.configuracionactividad VALUES (14, 9, 6, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (24, 19, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (28, 23, 8, 1, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (29, 24, 9, 4, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (34, 29, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (35, 30, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (36, 31, 12, 6, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (37, 32, 12, 6, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (38, 33, 13, 7, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (39, 34, 14, 8, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (40, 35, 15, 1, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (41, 36, 15, 1, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (42, 37, 15, 1, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (43, 35, 16, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (44, 36, 16, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (45, 37, 16, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (46, 38, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (47, 39, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (48, 40, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (49, 41, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (50, 42, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (51, 43, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (52, 44, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (53, 45, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (54, 46, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (55, 47, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (56, 48, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (57, 49, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (58, 50, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (59, 51, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (60, 52, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (61, 53, 11, 5, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (62, 54, 13, 7, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (27, 22, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (5, 5, 2, 1, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (10, 5, 4, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (11, 6, 5, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (12, 7, 5, 2, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (26, 21, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (20, 15, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (13, 8, 6, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (15, 10, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (16, 11, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (17, 12, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (18, 13, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (19, 14, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (21, 16, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (22, 17, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (23, 18, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (25, 20, 7, 3, true, false, NULL, NULL);
INSERT INTO public.configuracionactividad VALUES (1, 1, 1, 1, true, true, 10.0000, 40);
INSERT INTO public.configuracionactividad VALUES (2, 2, 1, 1, true, true, 10.0000, 41);
INSERT INTO public.configuracionactividad VALUES (3, 3, 1, 1, true, true, 10.0000, 40);
INSERT INTO public.configuracionactividad VALUES (4, 4, 1, 1, true, true, 10.0000, 41);
INSERT INTO public.configuracionactividad VALUES (30, 25, 10, 2, true, true, 10.0000, 43);
INSERT INTO public.configuracionactividad VALUES (31, 26, 10, 2, true, true, 10.0000, 44);
INSERT INTO public.configuracionactividad VALUES (32, 27, 10, 2, true, true, 10.0000, 43);
INSERT INTO public.configuracionactividad VALUES (33, 28, 10, 2, true, true, 10.0000, 44);
INSERT INTO public.configuracionactividad VALUES (8, 3, 3, 2, true, true, 10.0000, 43);
INSERT INTO public.configuracionactividad VALUES (9, 4, 3, 2, true, true, 10.0000, 44);
INSERT INTO public.configuracionactividad VALUES (6, 1, 3, 2, true, true, 10.0000, 43);
INSERT INTO public.configuracionactividad VALUES (7, 2, 3, 2, true, true, 10.0000, 44);


--
-- TOC entry 3554 (class 0 OID 16990)
-- Dependencies: 247
-- Data for Name: departamento; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.departamento VALUES (5, 'ANTIOQUIA');
INSERT INTO public.departamento VALUES (8, 'ATLÁNTICO');
INSERT INTO public.departamento VALUES (11, 'BOGOTÁ, D.C.');
INSERT INTO public.departamento VALUES (13, 'BOLÍVAR');
INSERT INTO public.departamento VALUES (15, 'BOYACÁ');
INSERT INTO public.departamento VALUES (17, 'CALDAS');
INSERT INTO public.departamento VALUES (18, 'CAQUETÁ');
INSERT INTO public.departamento VALUES (19, 'CAUCA');
INSERT INTO public.departamento VALUES (20, 'CESAR');
INSERT INTO public.departamento VALUES (23, 'CÓRDOBA');
INSERT INTO public.departamento VALUES (25, 'CUNDINAMARCA');
INSERT INTO public.departamento VALUES (27, 'CHOCÓ');
INSERT INTO public.departamento VALUES (41, 'HUILA');
INSERT INTO public.departamento VALUES (44, 'LA GUAJIRA');
INSERT INTO public.departamento VALUES (47, 'MAGDALENA');
INSERT INTO public.departamento VALUES (50, 'META');
INSERT INTO public.departamento VALUES (52, 'NARIÑO');
INSERT INTO public.departamento VALUES (54, 'NORTE DE SANTANDER');
INSERT INTO public.departamento VALUES (63, 'QUINDÍO');
INSERT INTO public.departamento VALUES (66, 'RISARALDA');
INSERT INTO public.departamento VALUES (68, 'SANTANDER');
INSERT INTO public.departamento VALUES (70, 'SUCRE');
INSERT INTO public.departamento VALUES (73, 'TOLIMA');
INSERT INTO public.departamento VALUES (76, 'VALLE DEL CAUCA');
INSERT INTO public.departamento VALUES (81, 'ARAUCA');
INSERT INTO public.departamento VALUES (85, 'CASANARE');
INSERT INTO public.departamento VALUES (86, 'PUTUMAYO');
INSERT INTO public.departamento VALUES (88, 'ARCHIPIÉLAGO DE SAN ANDRÉS, PROVIDENCIA Y SANTA CATALINA');
INSERT INTO public.departamento VALUES (91, 'AMAZONAS');
INSERT INTO public.departamento VALUES (94, 'GUAINÍA');
INSERT INTO public.departamento VALUES (95, 'GUAVIARE');
INSERT INTO public.departamento VALUES (97, 'VAUPÉS');
INSERT INTO public.departamento VALUES (99, 'VICHADA');


--
-- TOC entry 3555 (class 0 OID 16995)
-- Dependencies: 248
-- Data for Name: municipio; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.municipio VALUES (5001, 'MEDELLÍN', 5);
INSERT INTO public.municipio VALUES (5002, 'ABEJORRAL', 5);
INSERT INTO public.municipio VALUES (5004, 'ABRIAQUÍ', 5);
INSERT INTO public.municipio VALUES (5021, 'ALEJANDRÍA', 5);
INSERT INTO public.municipio VALUES (5030, 'AMAGÁ', 5);
INSERT INTO public.municipio VALUES (5031, 'AMALFI', 5);
INSERT INTO public.municipio VALUES (5034, 'ANDES', 5);
INSERT INTO public.municipio VALUES (5036, 'ANGELÓPOLIS', 5);
INSERT INTO public.municipio VALUES (5038, 'ANGOSTURA', 5);
INSERT INTO public.municipio VALUES (5040, 'ANORÍ', 5);
INSERT INTO public.municipio VALUES (5042, 'SANTA FÉ DE ANTIOQUIA', 5);
INSERT INTO public.municipio VALUES (5044, 'ANZÁ', 5);
INSERT INTO public.municipio VALUES (5045, 'APARTADÓ', 5);
INSERT INTO public.municipio VALUES (5051, 'ARBOLETES', 5);
INSERT INTO public.municipio VALUES (5055, 'ARGELIA', 5);
INSERT INTO public.municipio VALUES (5059, 'ARMENIA', 5);
INSERT INTO public.municipio VALUES (5079, 'BARBOSA', 5);
INSERT INTO public.municipio VALUES (5086, 'BELMIRA', 5);
INSERT INTO public.municipio VALUES (5088, 'BELLO', 5);
INSERT INTO public.municipio VALUES (5091, 'BETANIA', 5);
INSERT INTO public.municipio VALUES (5093, 'BETULIA', 5);
INSERT INTO public.municipio VALUES (5101, 'CIUDAD BOLÍVAR', 5);
INSERT INTO public.municipio VALUES (5107, 'BRICEÑO', 5);
INSERT INTO public.municipio VALUES (5113, 'BURITICÁ', 5);
INSERT INTO public.municipio VALUES (5120, 'CÁCERES', 5);
INSERT INTO public.municipio VALUES (5125, 'CAICEDO', 5);
INSERT INTO public.municipio VALUES (5129, 'CALDAS', 5);
INSERT INTO public.municipio VALUES (5134, 'CAMPAMENTO', 5);
INSERT INTO public.municipio VALUES (5138, 'CAÑASGORDAS', 5);
INSERT INTO public.municipio VALUES (5142, 'CARACOLÍ', 5);
INSERT INTO public.municipio VALUES (5145, 'CARAMANTA', 5);
INSERT INTO public.municipio VALUES (5147, 'CAREPA', 5);
INSERT INTO public.municipio VALUES (5148, 'EL CARMEN DE VIBORAL', 5);
INSERT INTO public.municipio VALUES (5150, 'CAROLINA', 5);
INSERT INTO public.municipio VALUES (5154, 'CAUCASIA', 5);
INSERT INTO public.municipio VALUES (5172, 'CHIGORODÓ', 5);
INSERT INTO public.municipio VALUES (5190, 'CISNEROS', 5);
INSERT INTO public.municipio VALUES (5197, 'COCORNÁ', 5);
INSERT INTO public.municipio VALUES (5206, 'CONCEPCIÓN', 5);
INSERT INTO public.municipio VALUES (5209, 'CONCORDIA', 5);
INSERT INTO public.municipio VALUES (5212, 'COPACABANA', 5);
INSERT INTO public.municipio VALUES (5234, 'DABEIBA', 5);
INSERT INTO public.municipio VALUES (5237, 'DONMATÍAS', 5);
INSERT INTO public.municipio VALUES (5240, 'EBÉJICO', 5);
INSERT INTO public.municipio VALUES (5250, 'EL BAGRE', 5);
INSERT INTO public.municipio VALUES (5264, 'ENTRERRÍOS', 5);
INSERT INTO public.municipio VALUES (5266, 'ENVIGADO', 5);
INSERT INTO public.municipio VALUES (5282, 'FREDONIA', 5);
INSERT INTO public.municipio VALUES (5284, 'FRONTINO', 5);
INSERT INTO public.municipio VALUES (5306, 'GIRALDO', 5);
INSERT INTO public.municipio VALUES (5308, 'GIRARDOTA', 5);
INSERT INTO public.municipio VALUES (5310, 'GÓMEZ PLATA', 5);
INSERT INTO public.municipio VALUES (5313, 'GRANADA', 5);
INSERT INTO public.municipio VALUES (5315, 'GUADALUPE', 5);
INSERT INTO public.municipio VALUES (5318, 'GUARNE', 5);
INSERT INTO public.municipio VALUES (5321, 'GUATAPÉ', 5);
INSERT INTO public.municipio VALUES (5347, 'HELICONIA', 5);
INSERT INTO public.municipio VALUES (5353, 'HISPANIA', 5);
INSERT INTO public.municipio VALUES (5360, 'ITAGÜÍ', 5);
INSERT INTO public.municipio VALUES (5361, 'ITUANGO', 5);
INSERT INTO public.municipio VALUES (5364, 'JARDÍN', 5);
INSERT INTO public.municipio VALUES (5368, 'JERICÓ', 5);
INSERT INTO public.municipio VALUES (5376, 'LA CEJA', 5);
INSERT INTO public.municipio VALUES (5380, 'LA ESTRELLA', 5);
INSERT INTO public.municipio VALUES (5390, 'LA PINTADA', 5);
INSERT INTO public.municipio VALUES (5400, 'LA UNIÓN', 5);
INSERT INTO public.municipio VALUES (5411, 'LIBORINA', 5);
INSERT INTO public.municipio VALUES (5425, 'MACEO', 5);
INSERT INTO public.municipio VALUES (5440, 'MARINILLA', 5);
INSERT INTO public.municipio VALUES (5467, 'MONTEBELLO', 5);
INSERT INTO public.municipio VALUES (5475, 'MURINDÓ', 5);
INSERT INTO public.municipio VALUES (5480, 'MUTATÁ', 5);
INSERT INTO public.municipio VALUES (5483, 'NARIÑO', 5);
INSERT INTO public.municipio VALUES (5490, 'NECOCLÍ', 5);
INSERT INTO public.municipio VALUES (5495, 'NECHÍ', 5);
INSERT INTO public.municipio VALUES (5501, 'OLAYA', 5);
INSERT INTO public.municipio VALUES (5541, 'PEÑOL', 5);
INSERT INTO public.municipio VALUES (5543, 'PEQUE', 5);
INSERT INTO public.municipio VALUES (5576, 'PUEBLORRICO', 5);
INSERT INTO public.municipio VALUES (5579, 'PUERTO BERRÍO', 5);
INSERT INTO public.municipio VALUES (5585, 'PUERTO NARE', 5);
INSERT INTO public.municipio VALUES (5591, 'PUERTO TRIUNFO', 5);
INSERT INTO public.municipio VALUES (5604, 'REMEDIOS', 5);
INSERT INTO public.municipio VALUES (5607, 'RETIRO', 5);
INSERT INTO public.municipio VALUES (5615, 'RIONEGRO', 5);
INSERT INTO public.municipio VALUES (5628, 'SABANALARGA', 5);
INSERT INTO public.municipio VALUES (5631, 'SABANETA', 5);
INSERT INTO public.municipio VALUES (5642, 'SALGAR', 5);
INSERT INTO public.municipio VALUES (5647, 'SAN ANDRÉS DE CUERQUÍA', 5);
INSERT INTO public.municipio VALUES (5649, 'SAN CARLOS', 5);
INSERT INTO public.municipio VALUES (5652, 'SAN FRANCISCO', 5);
INSERT INTO public.municipio VALUES (5656, 'SAN JERÓNIMO', 5);
INSERT INTO public.municipio VALUES (5658, 'SAN JOSÉ DE LA MONTAÑA', 5);
INSERT INTO public.municipio VALUES (5659, 'SAN JUAN DE URABÁ', 5);
INSERT INTO public.municipio VALUES (5660, 'SAN LUIS', 5);
INSERT INTO public.municipio VALUES (5664, 'SAN PEDRO DE LOS MILAGROS', 5);
INSERT INTO public.municipio VALUES (5665, 'SAN PEDRO DE URABÁ', 5);
INSERT INTO public.municipio VALUES (5667, 'SAN RAFAEL', 5);
INSERT INTO public.municipio VALUES (5670, 'SAN ROQUE', 5);
INSERT INTO public.municipio VALUES (5674, 'SAN VICENTE FERRER', 5);
INSERT INTO public.municipio VALUES (5679, 'SANTA BÁRBARA', 5);
INSERT INTO public.municipio VALUES (5686, 'SANTA ROSA DE OSOS', 5);
INSERT INTO public.municipio VALUES (5690, 'SANTO DOMINGO', 5);
INSERT INTO public.municipio VALUES (5697, 'EL SANTUARIO', 5);
INSERT INTO public.municipio VALUES (5736, 'SEGOVIA', 5);
INSERT INTO public.municipio VALUES (5756, 'SONSÓN', 5);
INSERT INTO public.municipio VALUES (5761, 'SOPETRÁN', 5);
INSERT INTO public.municipio VALUES (5789, 'TÁMESIS', 5);
INSERT INTO public.municipio VALUES (5790, 'TARAZÁ', 5);
INSERT INTO public.municipio VALUES (5792, 'TARSO', 5);
INSERT INTO public.municipio VALUES (5809, 'TITIRIBÍ', 5);
INSERT INTO public.municipio VALUES (5819, 'TOLEDO', 5);
INSERT INTO public.municipio VALUES (5837, 'TURBO', 5);
INSERT INTO public.municipio VALUES (5842, 'URAMITA', 5);
INSERT INTO public.municipio VALUES (5847, 'URRAO', 5);
INSERT INTO public.municipio VALUES (5854, 'VALDIVIA', 5);
INSERT INTO public.municipio VALUES (5856, 'VALPARAÍSO', 5);
INSERT INTO public.municipio VALUES (5858, 'VEGACHÍ', 5);
INSERT INTO public.municipio VALUES (5861, 'VENECIA', 5);
INSERT INTO public.municipio VALUES (5873, 'VIGÍA DEL FUERTE', 5);
INSERT INTO public.municipio VALUES (5885, 'YALÍ', 5);
INSERT INTO public.municipio VALUES (5887, 'YARUMAL', 5);
INSERT INTO public.municipio VALUES (5890, 'YOLOMBÓ', 5);
INSERT INTO public.municipio VALUES (5893, 'YONDÓ', 5);
INSERT INTO public.municipio VALUES (5895, 'ZARAGOZA', 5);
INSERT INTO public.municipio VALUES (8001, 'BARRANQUILLA', 8);
INSERT INTO public.municipio VALUES (8078, 'BARANOA', 8);
INSERT INTO public.municipio VALUES (8137, 'CAMPO DE LA CRUZ', 8);
INSERT INTO public.municipio VALUES (8141, 'CANDELARIA', 8);
INSERT INTO public.municipio VALUES (8296, 'GALAPA', 8);
INSERT INTO public.municipio VALUES (8372, 'JUAN DE ACOSTA', 8);
INSERT INTO public.municipio VALUES (8421, 'LURUACO', 8);
INSERT INTO public.municipio VALUES (8433, 'MALAMBO', 8);
INSERT INTO public.municipio VALUES (8436, 'MANATÍ', 8);
INSERT INTO public.municipio VALUES (8520, 'PALMAR DE VARELA', 8);
INSERT INTO public.municipio VALUES (8549, 'PIOJÓ', 8);
INSERT INTO public.municipio VALUES (8558, 'POLONUEVO', 8);
INSERT INTO public.municipio VALUES (8560, 'PONEDERA', 8);
INSERT INTO public.municipio VALUES (8573, 'PUERTO COLOMBIA', 8);
INSERT INTO public.municipio VALUES (8606, 'REPELÓN', 8);
INSERT INTO public.municipio VALUES (8634, 'SABANAGRANDE', 8);
INSERT INTO public.municipio VALUES (8638, 'SABANALARGA', 8);
INSERT INTO public.municipio VALUES (8675, 'SANTA LUCÍA', 8);
INSERT INTO public.municipio VALUES (8685, 'SANTO TOMÁS', 8);
INSERT INTO public.municipio VALUES (8758, 'SOLEDAD', 8);
INSERT INTO public.municipio VALUES (8770, 'SUAN', 8);
INSERT INTO public.municipio VALUES (8832, 'TUBARÁ', 8);
INSERT INTO public.municipio VALUES (8849, 'USIACURÍ', 8);
INSERT INTO public.municipio VALUES (11001, 'BOGOTÁ, D.C.', 11);
INSERT INTO public.municipio VALUES (13001, 'CARTAGENA DE INDIAS', 13);
INSERT INTO public.municipio VALUES (13006, 'ACHÍ', 13);
INSERT INTO public.municipio VALUES (13030, 'ALTOS DEL ROSARIO', 13);
INSERT INTO public.municipio VALUES (13042, 'ARENAL', 13);
INSERT INTO public.municipio VALUES (13052, 'ARJONA', 13);
INSERT INTO public.municipio VALUES (13062, 'ARROYOHONDO', 13);
INSERT INTO public.municipio VALUES (13074, 'BARRANCO DE LOBA', 13);
INSERT INTO public.municipio VALUES (13140, 'CALAMAR', 13);
INSERT INTO public.municipio VALUES (13160, 'CANTAGALLO', 13);
INSERT INTO public.municipio VALUES (13188, 'CICUCO', 13);
INSERT INTO public.municipio VALUES (13212, 'CÓRDOBA', 13);
INSERT INTO public.municipio VALUES (13222, 'CLEMENCIA', 13);
INSERT INTO public.municipio VALUES (13244, 'EL CARMEN DE BOLÍVAR', 13);
INSERT INTO public.municipio VALUES (13248, 'EL GUAMO', 13);
INSERT INTO public.municipio VALUES (13268, 'EL PEÑÓN', 13);
INSERT INTO public.municipio VALUES (13300, 'HATILLO DE LOBA', 13);
INSERT INTO public.municipio VALUES (13430, 'MAGANGUÉ', 13);
INSERT INTO public.municipio VALUES (13433, 'MAHATES', 13);
INSERT INTO public.municipio VALUES (13440, 'MARGARITA', 13);
INSERT INTO public.municipio VALUES (13442, 'MARÍA LA BAJA', 13);
INSERT INTO public.municipio VALUES (13458, 'MONTECRISTO', 13);
INSERT INTO public.municipio VALUES (13468, 'SANTA CRUZ DE MOMPOX', 13);
INSERT INTO public.municipio VALUES (13473, 'MORALES', 13);
INSERT INTO public.municipio VALUES (13490, 'NOROSÍ', 13);
INSERT INTO public.municipio VALUES (13549, 'PINILLOS', 13);
INSERT INTO public.municipio VALUES (13580, 'REGIDOR', 13);
INSERT INTO public.municipio VALUES (13600, 'RÍO VIEJO', 13);
INSERT INTO public.municipio VALUES (13620, 'SAN CRISTÓBAL', 13);
INSERT INTO public.municipio VALUES (13647, 'SAN ESTANISLAO', 13);
INSERT INTO public.municipio VALUES (13650, 'SAN FERNANDO', 13);
INSERT INTO public.municipio VALUES (13654, 'SAN JACINTO', 13);
INSERT INTO public.municipio VALUES (13655, 'SAN JACINTO DEL CAUCA', 13);
INSERT INTO public.municipio VALUES (13657, 'SAN JUAN NEPOMUCENO', 13);
INSERT INTO public.municipio VALUES (13667, 'SAN MARTÍN DE LOBA', 13);
INSERT INTO public.municipio VALUES (13670, 'SAN PABLO', 13);
INSERT INTO public.municipio VALUES (13673, 'SANTA CATALINA', 13);
INSERT INTO public.municipio VALUES (13683, 'SANTA ROSA', 13);
INSERT INTO public.municipio VALUES (13688, 'SANTA ROSA DEL SUR', 13);
INSERT INTO public.municipio VALUES (13744, 'SIMITÍ', 13);
INSERT INTO public.municipio VALUES (13760, 'SOPLAVIENTO', 13);
INSERT INTO public.municipio VALUES (13780, 'TALAIGUA NUEVO', 13);
INSERT INTO public.municipio VALUES (13810, 'TIQUISIO', 13);
INSERT INTO public.municipio VALUES (13836, 'TURBACO', 13);
INSERT INTO public.municipio VALUES (13838, 'TURBANA', 13);
INSERT INTO public.municipio VALUES (13873, 'VILLANUEVA', 13);
INSERT INTO public.municipio VALUES (13894, 'ZAMBRANO', 13);
INSERT INTO public.municipio VALUES (15001, 'TUNJA', 15);
INSERT INTO public.municipio VALUES (15022, 'ALMEIDA', 15);
INSERT INTO public.municipio VALUES (15047, 'AQUITANIA', 15);
INSERT INTO public.municipio VALUES (15051, 'ARCABUCO', 15);
INSERT INTO public.municipio VALUES (15087, 'BELÉN', 15);
INSERT INTO public.municipio VALUES (15090, 'BERBEO', 15);
INSERT INTO public.municipio VALUES (15092, 'BETÉITIVA', 15);
INSERT INTO public.municipio VALUES (15097, 'BOAVITA', 15);
INSERT INTO public.municipio VALUES (15104, 'BOYACÁ', 15);
INSERT INTO public.municipio VALUES (15106, 'BRICEÑO', 15);
INSERT INTO public.municipio VALUES (15109, 'BUENAVISTA', 15);
INSERT INTO public.municipio VALUES (15114, 'BUSBANZÁ', 15);
INSERT INTO public.municipio VALUES (15131, 'CALDAS', 15);
INSERT INTO public.municipio VALUES (15135, 'CAMPOHERMOSO', 15);
INSERT INTO public.municipio VALUES (15162, 'CERINZA', 15);
INSERT INTO public.municipio VALUES (15172, 'CHINAVITA', 15);
INSERT INTO public.municipio VALUES (15176, 'CHIQUINQUIRÁ', 15);
INSERT INTO public.municipio VALUES (15180, 'CHISCAS', 15);
INSERT INTO public.municipio VALUES (15183, 'CHITA', 15);
INSERT INTO public.municipio VALUES (15185, 'CHITARAQUE', 15);
INSERT INTO public.municipio VALUES (15187, 'CHIVATÁ', 15);
INSERT INTO public.municipio VALUES (15189, 'CIÉNEGA', 15);
INSERT INTO public.municipio VALUES (15204, 'CÓMBITA', 15);
INSERT INTO public.municipio VALUES (15212, 'COPER', 15);
INSERT INTO public.municipio VALUES (15215, 'CORRALES', 15);
INSERT INTO public.municipio VALUES (15218, 'COVARACHÍA', 15);
INSERT INTO public.municipio VALUES (15223, 'CUBARÁ', 15);
INSERT INTO public.municipio VALUES (15224, 'CUCAITA', 15);
INSERT INTO public.municipio VALUES (15226, 'CUÍTIVA', 15);
INSERT INTO public.municipio VALUES (15232, 'CHÍQUIZA', 15);
INSERT INTO public.municipio VALUES (15236, 'CHIVOR', 15);
INSERT INTO public.municipio VALUES (15238, 'DUITAMA', 15);
INSERT INTO public.municipio VALUES (15244, 'EL COCUY', 15);
INSERT INTO public.municipio VALUES (15248, 'EL ESPINO', 15);
INSERT INTO public.municipio VALUES (15272, 'FIRAVITOBA', 15);
INSERT INTO public.municipio VALUES (15276, 'FLORESTA', 15);
INSERT INTO public.municipio VALUES (15293, 'GACHANTIVÁ', 15);
INSERT INTO public.municipio VALUES (15296, 'GÁMEZA', 15);
INSERT INTO public.municipio VALUES (15299, 'GARAGOA', 15);
INSERT INTO public.municipio VALUES (15317, 'GUACAMAYAS', 15);
INSERT INTO public.municipio VALUES (15322, 'GUATEQUE', 15);
INSERT INTO public.municipio VALUES (15325, 'GUAYATÁ', 15);
INSERT INTO public.municipio VALUES (15332, 'GÜICÁN DE LA SIERRA', 15);
INSERT INTO public.municipio VALUES (15362, 'IZA', 15);
INSERT INTO public.municipio VALUES (15367, 'JENESANO', 15);
INSERT INTO public.municipio VALUES (15368, 'JERICÓ', 15);
INSERT INTO public.municipio VALUES (15377, 'LABRANZAGRANDE', 15);
INSERT INTO public.municipio VALUES (15380, 'LA CAPILLA', 15);
INSERT INTO public.municipio VALUES (15401, 'LA VICTORIA', 15);
INSERT INTO public.municipio VALUES (15403, 'LA UVITA', 15);
INSERT INTO public.municipio VALUES (15407, 'VILLA DE LEYVA', 15);
INSERT INTO public.municipio VALUES (15425, 'MACANAL', 15);
INSERT INTO public.municipio VALUES (15442, 'MARIPÍ', 15);
INSERT INTO public.municipio VALUES (15455, 'MIRAFLORES', 15);
INSERT INTO public.municipio VALUES (15464, 'MONGUA', 15);
INSERT INTO public.municipio VALUES (15466, 'MONGUÍ', 15);
INSERT INTO public.municipio VALUES (15469, 'MONIQUIRÁ', 15);
INSERT INTO public.municipio VALUES (15476, 'MOTAVITA', 15);
INSERT INTO public.municipio VALUES (15480, 'MUZO', 15);
INSERT INTO public.municipio VALUES (15491, 'NOBSA', 15);
INSERT INTO public.municipio VALUES (15494, 'NUEVO COLÓN', 15);
INSERT INTO public.municipio VALUES (15500, 'OICATÁ', 15);
INSERT INTO public.municipio VALUES (15507, 'OTANCHE', 15);
INSERT INTO public.municipio VALUES (15511, 'PACHAVITA', 15);
INSERT INTO public.municipio VALUES (15514, 'PÁEZ', 15);
INSERT INTO public.municipio VALUES (15516, 'PAIPA', 15);
INSERT INTO public.municipio VALUES (15518, 'PAJARITO', 15);
INSERT INTO public.municipio VALUES (15522, 'PANQUEBA', 15);
INSERT INTO public.municipio VALUES (15531, 'PAUNA', 15);
INSERT INTO public.municipio VALUES (15533, 'PAYA', 15);
INSERT INTO public.municipio VALUES (15537, 'PAZ DE RÍO', 15);
INSERT INTO public.municipio VALUES (15542, 'PESCA', 15);
INSERT INTO public.municipio VALUES (15550, 'PISBA', 15);
INSERT INTO public.municipio VALUES (15572, 'PUERTO BOYACÁ', 15);
INSERT INTO public.municipio VALUES (15580, 'QUÍPAMA', 15);
INSERT INTO public.municipio VALUES (15599, 'RAMIRIQUÍ', 15);
INSERT INTO public.municipio VALUES (15600, 'RÁQUIRA', 15);
INSERT INTO public.municipio VALUES (15621, 'RONDÓN', 15);
INSERT INTO public.municipio VALUES (15632, 'SABOYÁ', 15);
INSERT INTO public.municipio VALUES (15638, 'SÁCHICA', 15);
INSERT INTO public.municipio VALUES (15646, 'SAMACÁ', 15);
INSERT INTO public.municipio VALUES (15660, 'SAN EDUARDO', 15);
INSERT INTO public.municipio VALUES (15664, 'SAN JOSÉ DE PARE', 15);
INSERT INTO public.municipio VALUES (15667, 'SAN LUIS DE GACENO', 15);
INSERT INTO public.municipio VALUES (15673, 'SAN MATEO', 15);
INSERT INTO public.municipio VALUES (15676, 'SAN MIGUEL DE SEMA', 15);
INSERT INTO public.municipio VALUES (15681, 'SAN PABLO DE BORBUR', 15);
INSERT INTO public.municipio VALUES (15686, 'SANTANA', 15);
INSERT INTO public.municipio VALUES (15690, 'SANTA MARÍA', 15);
INSERT INTO public.municipio VALUES (15693, 'SANTA ROSA DE VITERBO', 15);
INSERT INTO public.municipio VALUES (15696, 'SANTA SOFÍA', 15);
INSERT INTO public.municipio VALUES (15720, 'SATIVANORTE', 15);
INSERT INTO public.municipio VALUES (15723, 'SATIVASUR', 15);
INSERT INTO public.municipio VALUES (15740, 'SIACHOQUE', 15);
INSERT INTO public.municipio VALUES (15753, 'SOATÁ', 15);
INSERT INTO public.municipio VALUES (15755, 'SOCOTÁ', 15);
INSERT INTO public.municipio VALUES (15757, 'SOCHA', 15);
INSERT INTO public.municipio VALUES (15759, 'SOGAMOSO', 15);
INSERT INTO public.municipio VALUES (15761, 'SOMONDOCO', 15);
INSERT INTO public.municipio VALUES (15762, 'SORA', 15);
INSERT INTO public.municipio VALUES (15763, 'SOTAQUIRÁ', 15);
INSERT INTO public.municipio VALUES (15764, 'SORACÁ', 15);
INSERT INTO public.municipio VALUES (15774, 'SUSACÓN', 15);
INSERT INTO public.municipio VALUES (15776, 'SUTAMARCHÁN', 15);
INSERT INTO public.municipio VALUES (15778, 'SUTATENZA', 15);
INSERT INTO public.municipio VALUES (15790, 'TASCO', 15);
INSERT INTO public.municipio VALUES (15798, 'TENZA', 15);
INSERT INTO public.municipio VALUES (15804, 'TIBANÁ', 15);
INSERT INTO public.municipio VALUES (15806, 'TIBASOSA', 15);
INSERT INTO public.municipio VALUES (15808, 'TINJACÁ', 15);
INSERT INTO public.municipio VALUES (15810, 'TIPACOQUE', 15);
INSERT INTO public.municipio VALUES (15814, 'TOCA', 15);
INSERT INTO public.municipio VALUES (15816, 'TOGÜÍ', 15);
INSERT INTO public.municipio VALUES (15820, 'TÓPAGA', 15);
INSERT INTO public.municipio VALUES (15822, 'TOTA', 15);
INSERT INTO public.municipio VALUES (15832, 'TUNUNGUÁ', 15);
INSERT INTO public.municipio VALUES (15835, 'TURMEQUÉ', 15);
INSERT INTO public.municipio VALUES (15837, 'TUTA', 15);
INSERT INTO public.municipio VALUES (15839, 'TUTAZÁ', 15);
INSERT INTO public.municipio VALUES (15842, 'ÚMBITA', 15);
INSERT INTO public.municipio VALUES (15861, 'VENTAQUEMADA', 15);
INSERT INTO public.municipio VALUES (15879, 'VIRACACHÁ', 15);
INSERT INTO public.municipio VALUES (15897, 'ZETAQUIRA', 15);
INSERT INTO public.municipio VALUES (17001, 'MANIZALES', 17);
INSERT INTO public.municipio VALUES (17013, 'AGUADAS', 17);
INSERT INTO public.municipio VALUES (17042, 'ANSERMA', 17);
INSERT INTO public.municipio VALUES (17050, 'ARANZAZU', 17);
INSERT INTO public.municipio VALUES (17088, 'BELALCÁZAR', 17);
INSERT INTO public.municipio VALUES (17174, 'CHINCHINÁ', 17);
INSERT INTO public.municipio VALUES (17272, 'FILADELFIA', 17);
INSERT INTO public.municipio VALUES (17380, 'LA DORADA', 17);
INSERT INTO public.municipio VALUES (17388, 'LA MERCED', 17);
INSERT INTO public.municipio VALUES (17433, 'MANZANARES', 17);
INSERT INTO public.municipio VALUES (17442, 'MARMATO', 17);
INSERT INTO public.municipio VALUES (17444, 'MARQUETALIA', 17);
INSERT INTO public.municipio VALUES (17446, 'MARULANDA', 17);
INSERT INTO public.municipio VALUES (17486, 'NEIRA', 17);
INSERT INTO public.municipio VALUES (17495, 'NORCASIA', 17);
INSERT INTO public.municipio VALUES (17513, 'PÁCORA', 17);
INSERT INTO public.municipio VALUES (17524, 'PALESTINA', 17);
INSERT INTO public.municipio VALUES (17541, 'PENSILVANIA', 17);
INSERT INTO public.municipio VALUES (17614, 'RIOSUCIO', 17);
INSERT INTO public.municipio VALUES (17616, 'RISARALDA', 17);
INSERT INTO public.municipio VALUES (17653, 'SALAMINA', 17);
INSERT INTO public.municipio VALUES (17662, 'SAMANÁ', 17);
INSERT INTO public.municipio VALUES (17665, 'SAN JOSÉ', 17);
INSERT INTO public.municipio VALUES (17777, 'SUPÍA', 17);
INSERT INTO public.municipio VALUES (17867, 'VICTORIA', 17);
INSERT INTO public.municipio VALUES (17873, 'VILLAMARÍA', 17);
INSERT INTO public.municipio VALUES (17877, 'VITERBO', 17);
INSERT INTO public.municipio VALUES (18001, 'FLORENCIA', 18);
INSERT INTO public.municipio VALUES (18029, 'ALBANIA', 18);
INSERT INTO public.municipio VALUES (18094, 'BELÉN DE LOS ANDAQUÍES', 18);
INSERT INTO public.municipio VALUES (18150, 'CARTAGENA DEL CHAIRÁ', 18);
INSERT INTO public.municipio VALUES (18205, 'CURILLO', 18);
INSERT INTO public.municipio VALUES (18247, 'EL DONCELLO', 18);
INSERT INTO public.municipio VALUES (18256, 'EL PAUJÍL', 18);
INSERT INTO public.municipio VALUES (18410, 'LA MONTAÑITA', 18);
INSERT INTO public.municipio VALUES (18460, 'MILÁN', 18);
INSERT INTO public.municipio VALUES (18479, 'MORELIA', 18);
INSERT INTO public.municipio VALUES (18592, 'PUERTO RICO', 18);
INSERT INTO public.municipio VALUES (18610, 'SAN JOSÉ DEL FRAGUA', 18);
INSERT INTO public.municipio VALUES (18753, 'SAN VICENTE DEL CAGUÁN', 18);
INSERT INTO public.municipio VALUES (18756, 'SOLANO', 18);
INSERT INTO public.municipio VALUES (18785, 'SOLITA', 18);
INSERT INTO public.municipio VALUES (18860, 'VALPARAÍSO', 18);
INSERT INTO public.municipio VALUES (19001, 'POPAYÁN', 19);
INSERT INTO public.municipio VALUES (19022, 'ALMAGUER', 19);
INSERT INTO public.municipio VALUES (19050, 'ARGELIA', 19);
INSERT INTO public.municipio VALUES (19075, 'BALBOA', 19);
INSERT INTO public.municipio VALUES (19100, 'BOLÍVAR', 19);
INSERT INTO public.municipio VALUES (19110, 'BUENOS AIRES', 19);
INSERT INTO public.municipio VALUES (19130, 'CAJIBÍO', 19);
INSERT INTO public.municipio VALUES (19137, 'CALDONO', 19);
INSERT INTO public.municipio VALUES (19142, 'CALOTO', 19);
INSERT INTO public.municipio VALUES (19212, 'CORINTO', 19);
INSERT INTO public.municipio VALUES (19256, 'EL TAMBO', 19);
INSERT INTO public.municipio VALUES (19290, 'FLORENCIA', 19);
INSERT INTO public.municipio VALUES (19300, 'GUACHENÉ', 19);
INSERT INTO public.municipio VALUES (19318, 'GUAPI', 19);
INSERT INTO public.municipio VALUES (19355, 'INZÁ', 19);
INSERT INTO public.municipio VALUES (19364, 'JAMBALÓ', 19);
INSERT INTO public.municipio VALUES (19392, 'LA SIERRA', 19);
INSERT INTO public.municipio VALUES (19397, 'LA VEGA', 19);
INSERT INTO public.municipio VALUES (19418, 'LÓPEZ DE MICAY', 19);
INSERT INTO public.municipio VALUES (19450, 'MERCADERES', 19);
INSERT INTO public.municipio VALUES (19455, 'MIRANDA', 19);
INSERT INTO public.municipio VALUES (19473, 'MORALES', 19);
INSERT INTO public.municipio VALUES (19513, 'PADILLA', 19);
INSERT INTO public.municipio VALUES (19517, 'PÁEZ', 19);
INSERT INTO public.municipio VALUES (19532, 'PATÍA', 19);
INSERT INTO public.municipio VALUES (19533, 'PIAMONTE', 19);
INSERT INTO public.municipio VALUES (19548, 'PIENDAMÓ - TUNÍA', 19);
INSERT INTO public.municipio VALUES (19573, 'PUERTO TEJADA', 19);
INSERT INTO public.municipio VALUES (19585, 'PURACÉ', 19);
INSERT INTO public.municipio VALUES (19622, 'ROSAS', 19);
INSERT INTO public.municipio VALUES (19693, 'SAN SEBASTIÁN', 19);
INSERT INTO public.municipio VALUES (19698, 'SANTANDER DE QUILICHAO', 19);
INSERT INTO public.municipio VALUES (19701, 'SANTA ROSA', 19);
INSERT INTO public.municipio VALUES (19743, 'SILVIA', 19);
INSERT INTO public.municipio VALUES (19760, 'SOTARÁ PAISPAMBA', 19);
INSERT INTO public.municipio VALUES (19780, 'SUÁREZ', 19);
INSERT INTO public.municipio VALUES (19785, 'SUCRE', 19);
INSERT INTO public.municipio VALUES (19807, 'TIMBÍO', 19);
INSERT INTO public.municipio VALUES (19809, 'TIMBIQUÍ', 19);
INSERT INTO public.municipio VALUES (19821, 'TORIBÍO', 19);
INSERT INTO public.municipio VALUES (19824, 'TOTORÓ', 19);
INSERT INTO public.municipio VALUES (19845, 'VILLA RICA', 19);
INSERT INTO public.municipio VALUES (20001, 'VALLEDUPAR', 20);
INSERT INTO public.municipio VALUES (20011, 'AGUACHICA', 20);
INSERT INTO public.municipio VALUES (20013, 'AGUSTÍN CODAZZI', 20);
INSERT INTO public.municipio VALUES (20032, 'ASTREA', 20);
INSERT INTO public.municipio VALUES (20045, 'BECERRIL', 20);
INSERT INTO public.municipio VALUES (20060, 'BOSCONIA', 20);
INSERT INTO public.municipio VALUES (20175, 'CHIMICHAGUA', 20);
INSERT INTO public.municipio VALUES (20178, 'CHIRIGUANÁ', 20);
INSERT INTO public.municipio VALUES (20228, 'CURUMANÍ', 20);
INSERT INTO public.municipio VALUES (20238, 'EL COPEY', 20);
INSERT INTO public.municipio VALUES (20250, 'EL PASO', 20);
INSERT INTO public.municipio VALUES (20295, 'GAMARRA', 20);
INSERT INTO public.municipio VALUES (20310, 'GONZÁLEZ', 20);
INSERT INTO public.municipio VALUES (20383, 'LA GLORIA', 20);
INSERT INTO public.municipio VALUES (20400, 'LA JAGUA DE IBIRICO', 20);
INSERT INTO public.municipio VALUES (20443, 'MANAURE BALCÓN DEL CESAR', 20);
INSERT INTO public.municipio VALUES (20517, 'PAILITAS', 20);
INSERT INTO public.municipio VALUES (20550, 'PELAYA', 20);
INSERT INTO public.municipio VALUES (20570, 'PUEBLO BELLO', 20);
INSERT INTO public.municipio VALUES (20614, 'RÍO DE ORO', 20);
INSERT INTO public.municipio VALUES (20621, 'LA PAZ', 20);
INSERT INTO public.municipio VALUES (20710, 'SAN ALBERTO', 20);
INSERT INTO public.municipio VALUES (20750, 'SAN DIEGO', 20);
INSERT INTO public.municipio VALUES (20770, 'SAN MARTÍN', 20);
INSERT INTO public.municipio VALUES (20787, 'TAMALAMEQUE', 20);
INSERT INTO public.municipio VALUES (23001, 'MONTERÍA', 23);
INSERT INTO public.municipio VALUES (23068, 'AYAPEL', 23);
INSERT INTO public.municipio VALUES (23079, 'BUENAVISTA', 23);
INSERT INTO public.municipio VALUES (23090, 'CANALETE', 23);
INSERT INTO public.municipio VALUES (23162, 'CERETÉ', 23);
INSERT INTO public.municipio VALUES (23168, 'CHIMÁ', 23);
INSERT INTO public.municipio VALUES (23182, 'CHINÚ', 23);
INSERT INTO public.municipio VALUES (23189, 'CIÉNAGA DE ORO', 23);
INSERT INTO public.municipio VALUES (23300, 'COTORRA', 23);
INSERT INTO public.municipio VALUES (23350, 'LA APARTADA', 23);
INSERT INTO public.municipio VALUES (23417, 'LORICA', 23);
INSERT INTO public.municipio VALUES (23419, 'LOS CÓRDOBAS', 23);
INSERT INTO public.municipio VALUES (23464, 'MOMIL', 23);
INSERT INTO public.municipio VALUES (23466, 'MONTELÍBANO', 23);
INSERT INTO public.municipio VALUES (23500, 'MOÑITOS', 23);
INSERT INTO public.municipio VALUES (23555, 'PLANETA RICA', 23);
INSERT INTO public.municipio VALUES (23570, 'PUEBLO NUEVO', 23);
INSERT INTO public.municipio VALUES (23574, 'PUERTO ESCONDIDO', 23);
INSERT INTO public.municipio VALUES (23580, 'PUERTO LIBERTADOR', 23);
INSERT INTO public.municipio VALUES (23586, 'PURÍSIMA DE LA CONCEPCIÓN', 23);
INSERT INTO public.municipio VALUES (23660, 'SAHAGÚN', 23);
INSERT INTO public.municipio VALUES (23670, 'SAN ANDRÉS DE SOTAVENTO', 23);
INSERT INTO public.municipio VALUES (23672, 'SAN ANTERO', 23);
INSERT INTO public.municipio VALUES (23675, 'SAN BERNARDO DEL VIENTO', 23);
INSERT INTO public.municipio VALUES (23678, 'SAN CARLOS', 23);
INSERT INTO public.municipio VALUES (23682, 'SAN JOSÉ DE URÉ', 23);
INSERT INTO public.municipio VALUES (23686, 'SAN PELAYO', 23);
INSERT INTO public.municipio VALUES (23807, 'TIERRALTA', 23);
INSERT INTO public.municipio VALUES (23815, 'TUCHÍN', 23);
INSERT INTO public.municipio VALUES (23855, 'VALENCIA', 23);
INSERT INTO public.municipio VALUES (25001, 'AGUA DE DIOS', 25);
INSERT INTO public.municipio VALUES (25019, 'ALBÁN', 25);
INSERT INTO public.municipio VALUES (25035, 'ANAPOIMA', 25);
INSERT INTO public.municipio VALUES (25040, 'ANOLAIMA', 25);
INSERT INTO public.municipio VALUES (25053, 'ARBELÁEZ', 25);
INSERT INTO public.municipio VALUES (25086, 'BELTRÁN', 25);
INSERT INTO public.municipio VALUES (25095, 'BITUIMA', 25);
INSERT INTO public.municipio VALUES (25099, 'BOJACÁ', 25);
INSERT INTO public.municipio VALUES (25120, 'CABRERA', 25);
INSERT INTO public.municipio VALUES (25123, 'CACHIPAY', 25);
INSERT INTO public.municipio VALUES (25126, 'CAJICÁ', 25);
INSERT INTO public.municipio VALUES (25148, 'CAPARRAPÍ', 25);
INSERT INTO public.municipio VALUES (25151, 'CÁQUEZA', 25);
INSERT INTO public.municipio VALUES (25154, 'CARMEN DE CARUPA', 25);
INSERT INTO public.municipio VALUES (25168, 'CHAGUANÍ', 25);
INSERT INTO public.municipio VALUES (25175, 'CHÍA', 25);
INSERT INTO public.municipio VALUES (25178, 'CHIPAQUE', 25);
INSERT INTO public.municipio VALUES (25181, 'CHOACHÍ', 25);
INSERT INTO public.municipio VALUES (25183, 'CHOCONTÁ', 25);
INSERT INTO public.municipio VALUES (25200, 'COGUA', 25);
INSERT INTO public.municipio VALUES (25214, 'COTA', 25);
INSERT INTO public.municipio VALUES (25224, 'CUCUNUBÁ', 25);
INSERT INTO public.municipio VALUES (25245, 'EL COLEGIO', 25);
INSERT INTO public.municipio VALUES (25258, 'EL PEÑÓN', 25);
INSERT INTO public.municipio VALUES (25260, 'EL ROSAL', 25);
INSERT INTO public.municipio VALUES (25269, 'FACATATIVÁ', 25);
INSERT INTO public.municipio VALUES (25279, 'FÓMEQUE', 25);
INSERT INTO public.municipio VALUES (25281, 'FOSCA', 25);
INSERT INTO public.municipio VALUES (25286, 'FUNZA', 25);
INSERT INTO public.municipio VALUES (25288, 'FÚQUENE', 25);
INSERT INTO public.municipio VALUES (25290, 'FUSAGASUGÁ', 25);
INSERT INTO public.municipio VALUES (25293, 'GACHALÁ', 25);
INSERT INTO public.municipio VALUES (25295, 'GACHANCIPÁ', 25);
INSERT INTO public.municipio VALUES (25297, 'GACHETÁ', 25);
INSERT INTO public.municipio VALUES (25299, 'GAMA', 25);
INSERT INTO public.municipio VALUES (25307, 'GIRARDOT', 25);
INSERT INTO public.municipio VALUES (25312, 'GRANADA', 25);
INSERT INTO public.municipio VALUES (25317, 'GUACHETÁ', 25);
INSERT INTO public.municipio VALUES (25320, 'GUADUAS', 25);
INSERT INTO public.municipio VALUES (25322, 'GUASCA', 25);
INSERT INTO public.municipio VALUES (25324, 'GUATAQUÍ', 25);
INSERT INTO public.municipio VALUES (25326, 'GUATAVITA', 25);
INSERT INTO public.municipio VALUES (25328, 'GUAYABAL DE SÍQUIMA', 25);
INSERT INTO public.municipio VALUES (25335, 'GUAYABETAL', 25);
INSERT INTO public.municipio VALUES (25339, 'GUTIÉRREZ', 25);
INSERT INTO public.municipio VALUES (25368, 'JERUSALÉN', 25);
INSERT INTO public.municipio VALUES (25372, 'JUNÍN', 25);
INSERT INTO public.municipio VALUES (25377, 'LA CALERA', 25);
INSERT INTO public.municipio VALUES (25386, 'LA MESA', 25);
INSERT INTO public.municipio VALUES (25394, 'LA PALMA', 25);
INSERT INTO public.municipio VALUES (25398, 'LA PEÑA', 25);
INSERT INTO public.municipio VALUES (25402, 'LA VEGA', 25);
INSERT INTO public.municipio VALUES (25407, 'LENGUAZAQUE', 25);
INSERT INTO public.municipio VALUES (25426, 'MACHETÁ', 25);
INSERT INTO public.municipio VALUES (25430, 'MADRID', 25);
INSERT INTO public.municipio VALUES (25436, 'MANTA', 25);
INSERT INTO public.municipio VALUES (25438, 'MEDINA', 25);
INSERT INTO public.municipio VALUES (25473, 'MOSQUERA', 25);
INSERT INTO public.municipio VALUES (25483, 'NARIÑO', 25);
INSERT INTO public.municipio VALUES (25486, 'NEMOCÓN', 25);
INSERT INTO public.municipio VALUES (25488, 'NILO', 25);
INSERT INTO public.municipio VALUES (25489, 'NIMAIMA', 25);
INSERT INTO public.municipio VALUES (25491, 'NOCAIMA', 25);
INSERT INTO public.municipio VALUES (25506, 'VENECIA', 25);
INSERT INTO public.municipio VALUES (25513, 'PACHO', 25);
INSERT INTO public.municipio VALUES (25518, 'PAIME', 25);
INSERT INTO public.municipio VALUES (25524, 'PANDI', 25);
INSERT INTO public.municipio VALUES (25530, 'PARATEBUENO', 25);
INSERT INTO public.municipio VALUES (25535, 'PASCA', 25);
INSERT INTO public.municipio VALUES (25572, 'PUERTO SALGAR', 25);
INSERT INTO public.municipio VALUES (25580, 'PULÍ', 25);
INSERT INTO public.municipio VALUES (25592, 'QUEBRADANEGRA', 25);
INSERT INTO public.municipio VALUES (25594, 'QUETAME', 25);
INSERT INTO public.municipio VALUES (25596, 'QUIPILE', 25);
INSERT INTO public.municipio VALUES (25599, 'APULO', 25);
INSERT INTO public.municipio VALUES (25612, 'RICAURTE', 25);
INSERT INTO public.municipio VALUES (25645, 'SAN ANTONIO DEL TEQUENDAMA', 25);
INSERT INTO public.municipio VALUES (25649, 'SAN BERNARDO', 25);
INSERT INTO public.municipio VALUES (25653, 'SAN CAYETANO', 25);
INSERT INTO public.municipio VALUES (25658, 'SAN FRANCISCO', 25);
INSERT INTO public.municipio VALUES (25662, 'SAN JUAN DE RIOSECO', 25);
INSERT INTO public.municipio VALUES (25718, 'SASAIMA', 25);
INSERT INTO public.municipio VALUES (25736, 'SESQUILÉ', 25);
INSERT INTO public.municipio VALUES (25740, 'SIBATÉ', 25);
INSERT INTO public.municipio VALUES (25743, 'SILVANIA', 25);
INSERT INTO public.municipio VALUES (25745, 'SIMIJACA', 25);
INSERT INTO public.municipio VALUES (25754, 'SOACHA', 25);
INSERT INTO public.municipio VALUES (25758, 'SOPÓ', 25);
INSERT INTO public.municipio VALUES (25769, 'SUBACHOQUE', 25);
INSERT INTO public.municipio VALUES (25772, 'SUESCA', 25);
INSERT INTO public.municipio VALUES (25777, 'SUPATÁ', 25);
INSERT INTO public.municipio VALUES (25779, 'SUSA', 25);
INSERT INTO public.municipio VALUES (25781, 'SUTATAUSA', 25);
INSERT INTO public.municipio VALUES (25785, 'TABIO', 25);
INSERT INTO public.municipio VALUES (25793, 'TAUSA', 25);
INSERT INTO public.municipio VALUES (25797, 'TENA', 25);
INSERT INTO public.municipio VALUES (25799, 'TENJO', 25);
INSERT INTO public.municipio VALUES (25805, 'TIBACUY', 25);
INSERT INTO public.municipio VALUES (25807, 'TIBIRITA', 25);
INSERT INTO public.municipio VALUES (25815, 'TOCAIMA', 25);
INSERT INTO public.municipio VALUES (25817, 'TOCANCIPÁ', 25);
INSERT INTO public.municipio VALUES (25823, 'TOPAIPÍ', 25);
INSERT INTO public.municipio VALUES (25839, 'UBALÁ', 25);
INSERT INTO public.municipio VALUES (25841, 'UBAQUE', 25);
INSERT INTO public.municipio VALUES (25843, 'VILLA DE SAN DIEGO DE UBATÉ', 25);
INSERT INTO public.municipio VALUES (25845, 'UNE', 25);
INSERT INTO public.municipio VALUES (25851, 'ÚTICA', 25);
INSERT INTO public.municipio VALUES (25862, 'VERGARA', 25);
INSERT INTO public.municipio VALUES (25867, 'VIANÍ', 25);
INSERT INTO public.municipio VALUES (25871, 'VILLAGÓMEZ', 25);
INSERT INTO public.municipio VALUES (25873, 'VILLAPINZÓN', 25);
INSERT INTO public.municipio VALUES (25875, 'VILLETA', 25);
INSERT INTO public.municipio VALUES (25878, 'VIOTÁ', 25);
INSERT INTO public.municipio VALUES (25885, 'YACOPÍ', 25);
INSERT INTO public.municipio VALUES (25898, 'ZIPACÓN', 25);
INSERT INTO public.municipio VALUES (25899, 'ZIPAQUIRÁ', 25);
INSERT INTO public.municipio VALUES (27001, 'QUIBDÓ', 27);
INSERT INTO public.municipio VALUES (27006, 'ACANDÍ', 27);
INSERT INTO public.municipio VALUES (27025, 'ALTO BAUDÓ', 27);
INSERT INTO public.municipio VALUES (27050, 'ATRATO', 27);
INSERT INTO public.municipio VALUES (27073, 'BAGADÓ', 27);
INSERT INTO public.municipio VALUES (27075, 'BAHÍA SOLANO', 27);
INSERT INTO public.municipio VALUES (27077, 'BAJO BAUDÓ', 27);
INSERT INTO public.municipio VALUES (27099, 'BOJAYÁ', 27);
INSERT INTO public.municipio VALUES (27135, 'EL CANTÓN DEL SAN PABLO', 27);
INSERT INTO public.municipio VALUES (27150, 'CARMEN DEL DARIÉN', 27);
INSERT INTO public.municipio VALUES (27160, 'CÉRTEGUI', 27);
INSERT INTO public.municipio VALUES (27205, 'CONDOTO', 27);
INSERT INTO public.municipio VALUES (27245, 'EL CARMEN DE ATRATO', 27);
INSERT INTO public.municipio VALUES (27250, 'EL LITORAL DEL SAN JUAN', 27);
INSERT INTO public.municipio VALUES (27361, 'ISTMINA', 27);
INSERT INTO public.municipio VALUES (27372, 'JURADÓ', 27);
INSERT INTO public.municipio VALUES (27413, 'LLORÓ', 27);
INSERT INTO public.municipio VALUES (27425, 'MEDIO ATRATO', 27);
INSERT INTO public.municipio VALUES (27430, 'MEDIO BAUDÓ', 27);
INSERT INTO public.municipio VALUES (27450, 'MEDIO SAN JUAN', 27);
INSERT INTO public.municipio VALUES (27491, 'NÓVITA', 27);
INSERT INTO public.municipio VALUES (27495, 'NUQUÍ', 27);
INSERT INTO public.municipio VALUES (27580, 'RÍO IRÓ', 27);
INSERT INTO public.municipio VALUES (27600, 'RÍO QUITO', 27);
INSERT INTO public.municipio VALUES (27615, 'RIOSUCIO', 27);
INSERT INTO public.municipio VALUES (27660, 'SAN JOSÉ DEL PALMAR', 27);
INSERT INTO public.municipio VALUES (27745, 'SIPÍ', 27);
INSERT INTO public.municipio VALUES (27787, 'TADÓ', 27);
INSERT INTO public.municipio VALUES (27800, 'UNGUÍA', 27);
INSERT INTO public.municipio VALUES (27810, 'UNIÓN PANAMERICANA', 27);
INSERT INTO public.municipio VALUES (41001, 'NEIVA', 41);
INSERT INTO public.municipio VALUES (41006, 'ACEVEDO', 41);
INSERT INTO public.municipio VALUES (41013, 'AGRADO', 41);
INSERT INTO public.municipio VALUES (41016, 'AIPE', 41);
INSERT INTO public.municipio VALUES (41020, 'ALGECIRAS', 41);
INSERT INTO public.municipio VALUES (41026, 'ALTAMIRA', 41);
INSERT INTO public.municipio VALUES (41078, 'BARAYA', 41);
INSERT INTO public.municipio VALUES (41132, 'CAMPOALEGRE', 41);
INSERT INTO public.municipio VALUES (41206, 'COLOMBIA', 41);
INSERT INTO public.municipio VALUES (41244, 'ELÍAS', 41);
INSERT INTO public.municipio VALUES (41298, 'GARZÓN', 41);
INSERT INTO public.municipio VALUES (41306, 'GIGANTE', 41);
INSERT INTO public.municipio VALUES (41319, 'GUADALUPE', 41);
INSERT INTO public.municipio VALUES (41349, 'HOBO', 41);
INSERT INTO public.municipio VALUES (41357, 'ÍQUIRA', 41);
INSERT INTO public.municipio VALUES (41359, 'ISNOS', 41);
INSERT INTO public.municipio VALUES (41378, 'LA ARGENTINA', 41);
INSERT INTO public.municipio VALUES (41396, 'LA PLATA', 41);
INSERT INTO public.municipio VALUES (41483, 'NÁTAGA', 41);
INSERT INTO public.municipio VALUES (41503, 'OPORAPA', 41);
INSERT INTO public.municipio VALUES (41518, 'PAICOL', 41);
INSERT INTO public.municipio VALUES (41524, 'PALERMO', 41);
INSERT INTO public.municipio VALUES (41530, 'PALESTINA', 41);
INSERT INTO public.municipio VALUES (41548, 'PITAL', 41);
INSERT INTO public.municipio VALUES (41551, 'PITALITO', 41);
INSERT INTO public.municipio VALUES (41615, 'RIVERA', 41);
INSERT INTO public.municipio VALUES (41660, 'SALADOBLANCO', 41);
INSERT INTO public.municipio VALUES (41668, 'SAN AGUSTÍN', 41);
INSERT INTO public.municipio VALUES (41676, 'SANTA MARÍA', 41);
INSERT INTO public.municipio VALUES (41770, 'SUAZA', 41);
INSERT INTO public.municipio VALUES (41791, 'TARQUI', 41);
INSERT INTO public.municipio VALUES (41797, 'TESALIA', 41);
INSERT INTO public.municipio VALUES (41799, 'TELLO', 41);
INSERT INTO public.municipio VALUES (41801, 'TERUEL', 41);
INSERT INTO public.municipio VALUES (41807, 'TIMANÁ', 41);
INSERT INTO public.municipio VALUES (41872, 'VILLAVIEJA', 41);
INSERT INTO public.municipio VALUES (41885, 'YAGUARÁ', 41);
INSERT INTO public.municipio VALUES (44001, 'RIOHACHA', 44);
INSERT INTO public.municipio VALUES (44035, 'ALBANIA', 44);
INSERT INTO public.municipio VALUES (44078, 'BARRANCAS', 44);
INSERT INTO public.municipio VALUES (44090, 'DIBULLA', 44);
INSERT INTO public.municipio VALUES (44098, 'DISTRACCIÓN', 44);
INSERT INTO public.municipio VALUES (44110, 'EL MOLINO', 44);
INSERT INTO public.municipio VALUES (44279, 'FONSECA', 44);
INSERT INTO public.municipio VALUES (44378, 'HATONUEVO', 44);
INSERT INTO public.municipio VALUES (44420, 'LA JAGUA DEL PILAR', 44);
INSERT INTO public.municipio VALUES (44430, 'MAICAO', 44);
INSERT INTO public.municipio VALUES (44560, 'MANAURE', 44);
INSERT INTO public.municipio VALUES (44650, 'SAN JUAN DEL CESAR', 44);
INSERT INTO public.municipio VALUES (44847, 'URIBIA', 44);
INSERT INTO public.municipio VALUES (44855, 'URUMITA', 44);
INSERT INTO public.municipio VALUES (44874, 'VILLANUEVA', 44);
INSERT INTO public.municipio VALUES (47001, 'SANTA MARTA', 47);
INSERT INTO public.municipio VALUES (47030, 'ALGARROBO', 47);
INSERT INTO public.municipio VALUES (47053, 'ARACATACA', 47);
INSERT INTO public.municipio VALUES (47058, 'ARIGUANÍ', 47);
INSERT INTO public.municipio VALUES (47161, 'CERRO DE SAN ANTONIO', 47);
INSERT INTO public.municipio VALUES (47170, 'CHIVOLO', 47);
INSERT INTO public.municipio VALUES (47189, 'CIÉNAGA', 47);
INSERT INTO public.municipio VALUES (47205, 'CONCORDIA', 47);
INSERT INTO public.municipio VALUES (47245, 'EL BANCO', 47);
INSERT INTO public.municipio VALUES (47258, 'EL PIÑÓN', 47);
INSERT INTO public.municipio VALUES (47268, 'EL RETÉN', 47);
INSERT INTO public.municipio VALUES (47288, 'FUNDACIÓN', 47);
INSERT INTO public.municipio VALUES (47318, 'GUAMAL', 47);
INSERT INTO public.municipio VALUES (47460, 'NUEVA GRANADA', 47);
INSERT INTO public.municipio VALUES (47541, 'PEDRAZA', 47);
INSERT INTO public.municipio VALUES (47545, 'PIJIÑO DEL CARMEN', 47);
INSERT INTO public.municipio VALUES (47551, 'PIVIJAY', 47);
INSERT INTO public.municipio VALUES (47555, 'PLATO', 47);
INSERT INTO public.municipio VALUES (47570, 'PUEBLOVIEJO', 47);
INSERT INTO public.municipio VALUES (47605, 'REMOLINO', 47);
INSERT INTO public.municipio VALUES (47660, 'SABANAS DE SAN ÁNGEL', 47);
INSERT INTO public.municipio VALUES (47675, 'SALAMINA', 47);
INSERT INTO public.municipio VALUES (47692, 'SAN SEBASTIÁN DE BUENAVISTA', 47);
INSERT INTO public.municipio VALUES (47703, 'SAN ZENÓN', 47);
INSERT INTO public.municipio VALUES (47707, 'SANTA ANA', 47);
INSERT INTO public.municipio VALUES (47720, 'SANTA BÁRBARA DE PINTO', 47);
INSERT INTO public.municipio VALUES (47745, 'SITIONUEVO', 47);
INSERT INTO public.municipio VALUES (47798, 'TENERIFE', 47);
INSERT INTO public.municipio VALUES (47960, 'ZAPAYÁN', 47);
INSERT INTO public.municipio VALUES (47980, 'ZONA BANANERA', 47);
INSERT INTO public.municipio VALUES (50001, 'VILLAVICENCIO', 50);
INSERT INTO public.municipio VALUES (50006, 'ACACÍAS', 50);
INSERT INTO public.municipio VALUES (50110, 'BARRANCA DE UPÍA', 50);
INSERT INTO public.municipio VALUES (50124, 'CABUYARO', 50);
INSERT INTO public.municipio VALUES (50150, 'CASTILLA LA NUEVA', 50);
INSERT INTO public.municipio VALUES (50223, 'CUBARRAL', 50);
INSERT INTO public.municipio VALUES (50226, 'CUMARAL', 50);
INSERT INTO public.municipio VALUES (50245, 'EL CALVARIO', 50);
INSERT INTO public.municipio VALUES (50251, 'EL CASTILLO', 50);
INSERT INTO public.municipio VALUES (50270, 'EL DORADO', 50);
INSERT INTO public.municipio VALUES (50287, 'FUENTE DE ORO', 50);
INSERT INTO public.municipio VALUES (50313, 'GRANADA', 50);
INSERT INTO public.municipio VALUES (50318, 'GUAMAL', 50);
INSERT INTO public.municipio VALUES (50325, 'MAPIRIPÁN', 50);
INSERT INTO public.municipio VALUES (50330, 'MESETAS', 50);
INSERT INTO public.municipio VALUES (50350, 'LA MACARENA', 50);
INSERT INTO public.municipio VALUES (50370, 'URIBE', 50);
INSERT INTO public.municipio VALUES (50400, 'LEJANÍAS', 50);
INSERT INTO public.municipio VALUES (50450, 'PUERTO CONCORDIA', 50);
INSERT INTO public.municipio VALUES (50568, 'PUERTO GAITÁN', 50);
INSERT INTO public.municipio VALUES (50573, 'PUERTO LÓPEZ', 50);
INSERT INTO public.municipio VALUES (50577, 'PUERTO LLERAS', 50);
INSERT INTO public.municipio VALUES (50590, 'PUERTO RICO', 50);
INSERT INTO public.municipio VALUES (50606, 'RESTREPO', 50);
INSERT INTO public.municipio VALUES (50680, 'SAN CARLOS DE GUAROA', 50);
INSERT INTO public.municipio VALUES (50683, 'SAN JUAN DE ARAMA', 50);
INSERT INTO public.municipio VALUES (50686, 'SAN JUANITO', 50);
INSERT INTO public.municipio VALUES (50689, 'SAN MARTÍN', 50);
INSERT INTO public.municipio VALUES (50711, 'VISTAHERMOSA', 50);
INSERT INTO public.municipio VALUES (52001, 'PASTO', 52);
INSERT INTO public.municipio VALUES (52019, 'ALBÁN', 52);
INSERT INTO public.municipio VALUES (52022, 'ALDANA', 52);
INSERT INTO public.municipio VALUES (52036, 'ANCUYA', 52);
INSERT INTO public.municipio VALUES (52051, 'ARBOLEDA', 52);
INSERT INTO public.municipio VALUES (52079, 'BARBACOAS', 52);
INSERT INTO public.municipio VALUES (52083, 'BELÉN', 52);
INSERT INTO public.municipio VALUES (52110, 'BUESACO', 52);
INSERT INTO public.municipio VALUES (52203, 'COLÓN', 52);
INSERT INTO public.municipio VALUES (52207, 'CONSACÁ', 52);
INSERT INTO public.municipio VALUES (52210, 'CONTADERO', 52);
INSERT INTO public.municipio VALUES (52215, 'CÓRDOBA', 52);
INSERT INTO public.municipio VALUES (52224, 'CUASPUD CARLOSAMA', 52);
INSERT INTO public.municipio VALUES (52227, 'CUMBAL', 52);
INSERT INTO public.municipio VALUES (52233, 'CUMBITARA', 52);
INSERT INTO public.municipio VALUES (52240, 'CHACHAGÜÍ', 52);
INSERT INTO public.municipio VALUES (52250, 'EL CHARCO', 52);
INSERT INTO public.municipio VALUES (52254, 'EL PEÑOL', 52);
INSERT INTO public.municipio VALUES (52256, 'EL ROSARIO', 52);
INSERT INTO public.municipio VALUES (52258, 'EL TABLÓN DE GÓMEZ', 52);
INSERT INTO public.municipio VALUES (52260, 'EL TAMBO', 52);
INSERT INTO public.municipio VALUES (52287, 'FUNES', 52);
INSERT INTO public.municipio VALUES (52317, 'GUACHUCAL', 52);
INSERT INTO public.municipio VALUES (52320, 'GUAITARILLA', 52);
INSERT INTO public.municipio VALUES (52323, 'GUALMATÁN', 52);
INSERT INTO public.municipio VALUES (52352, 'ILES', 52);
INSERT INTO public.municipio VALUES (52354, 'IMUÉS', 52);
INSERT INTO public.municipio VALUES (52356, 'IPIALES', 52);
INSERT INTO public.municipio VALUES (52378, 'LA CRUZ', 52);
INSERT INTO public.municipio VALUES (52381, 'LA FLORIDA', 52);
INSERT INTO public.municipio VALUES (52385, 'LA LLANADA', 52);
INSERT INTO public.municipio VALUES (52390, 'LA TOLA', 52);
INSERT INTO public.municipio VALUES (52399, 'LA UNIÓN', 52);
INSERT INTO public.municipio VALUES (52405, 'LEIVA', 52);
INSERT INTO public.municipio VALUES (52411, 'LINARES', 52);
INSERT INTO public.municipio VALUES (52418, 'LOS ANDES', 52);
INSERT INTO public.municipio VALUES (52427, 'MAGÜÍ', 52);
INSERT INTO public.municipio VALUES (52435, 'MALLAMA', 52);
INSERT INTO public.municipio VALUES (52473, 'MOSQUERA', 52);
INSERT INTO public.municipio VALUES (52480, 'NARIÑO', 52);
INSERT INTO public.municipio VALUES (52490, 'OLAYA HERRERA', 52);
INSERT INTO public.municipio VALUES (52506, 'OSPINA', 52);
INSERT INTO public.municipio VALUES (52520, 'FRANCISCO PIZARRO', 52);
INSERT INTO public.municipio VALUES (52540, 'POLICARPA', 52);
INSERT INTO public.municipio VALUES (52560, 'POTOSÍ', 52);
INSERT INTO public.municipio VALUES (52565, 'PROVIDENCIA', 52);
INSERT INTO public.municipio VALUES (52573, 'PUERRES', 52);
INSERT INTO public.municipio VALUES (52585, 'PUPIALES', 52);
INSERT INTO public.municipio VALUES (52612, 'RICAURTE', 52);
INSERT INTO public.municipio VALUES (52621, 'ROBERTO PAYÁN', 52);
INSERT INTO public.municipio VALUES (52678, 'SAMANIEGO', 52);
INSERT INTO public.municipio VALUES (52683, 'SANDONÁ', 52);
INSERT INTO public.municipio VALUES (52685, 'SAN BERNARDO', 52);
INSERT INTO public.municipio VALUES (52687, 'SAN LORENZO', 52);
INSERT INTO public.municipio VALUES (52693, 'SAN PABLO', 52);
INSERT INTO public.municipio VALUES (52694, 'SAN PEDRO DE CARTAGO', 52);
INSERT INTO public.municipio VALUES (52696, 'SANTA BÁRBARA', 52);
INSERT INTO public.municipio VALUES (52699, 'SANTACRUZ', 52);
INSERT INTO public.municipio VALUES (52720, 'SAPUYES', 52);
INSERT INTO public.municipio VALUES (52786, 'TAMINANGO', 52);
INSERT INTO public.municipio VALUES (52788, 'TANGUA', 52);
INSERT INTO public.municipio VALUES (52835, 'SAN ANDRÉS DE TUMACO', 52);
INSERT INTO public.municipio VALUES (52838, 'TÚQUERRES', 52);
INSERT INTO public.municipio VALUES (52885, 'YACUANQUER', 52);
INSERT INTO public.municipio VALUES (54001, 'SAN JOSÉ DE CÚCUTA', 54);
INSERT INTO public.municipio VALUES (54003, 'ÁBREGO', 54);
INSERT INTO public.municipio VALUES (54051, 'ARBOLEDAS', 54);
INSERT INTO public.municipio VALUES (54099, 'BOCHALEMA', 54);
INSERT INTO public.municipio VALUES (54109, 'BUCARASICA', 54);
INSERT INTO public.municipio VALUES (54125, 'CÁCOTA', 54);
INSERT INTO public.municipio VALUES (54128, 'CÁCHIRA', 54);
INSERT INTO public.municipio VALUES (54172, 'CHINÁCOTA', 54);
INSERT INTO public.municipio VALUES (54174, 'CHITAGÁ', 54);
INSERT INTO public.municipio VALUES (54206, 'CONVENCIÓN', 54);
INSERT INTO public.municipio VALUES (54223, 'CUCUTILLA', 54);
INSERT INTO public.municipio VALUES (54239, 'DURANIA', 54);
INSERT INTO public.municipio VALUES (54245, 'EL CARMEN', 54);
INSERT INTO public.municipio VALUES (54250, 'EL TARRA', 54);
INSERT INTO public.municipio VALUES (54261, 'EL ZULIA', 54);
INSERT INTO public.municipio VALUES (54313, 'GRAMALOTE', 54);
INSERT INTO public.municipio VALUES (54344, 'HACARÍ', 54);
INSERT INTO public.municipio VALUES (54347, 'HERRÁN', 54);
INSERT INTO public.municipio VALUES (54377, 'LABATECA', 54);
INSERT INTO public.municipio VALUES (54385, 'LA ESPERANZA', 54);
INSERT INTO public.municipio VALUES (54398, 'LA PLAYA', 54);
INSERT INTO public.municipio VALUES (54405, 'LOS PATIOS', 54);
INSERT INTO public.municipio VALUES (54418, 'LOURDES', 54);
INSERT INTO public.municipio VALUES (54480, 'MUTISCUA', 54);
INSERT INTO public.municipio VALUES (54498, 'OCAÑA', 54);
INSERT INTO public.municipio VALUES (54518, 'PAMPLONA', 54);
INSERT INTO public.municipio VALUES (54520, 'PAMPLONITA', 54);
INSERT INTO public.municipio VALUES (54553, 'PUERTO SANTANDER', 54);
INSERT INTO public.municipio VALUES (54599, 'RAGONVALIA', 54);
INSERT INTO public.municipio VALUES (54660, 'SALAZAR', 54);
INSERT INTO public.municipio VALUES (54670, 'SAN CALIXTO', 54);
INSERT INTO public.municipio VALUES (54673, 'SAN CAYETANO', 54);
INSERT INTO public.municipio VALUES (54680, 'SANTIAGO', 54);
INSERT INTO public.municipio VALUES (54720, 'SARDINATA', 54);
INSERT INTO public.municipio VALUES (54743, 'SILOS', 54);
INSERT INTO public.municipio VALUES (54800, 'TEORAMA', 54);
INSERT INTO public.municipio VALUES (54810, 'TIBÚ', 54);
INSERT INTO public.municipio VALUES (54820, 'TOLEDO', 54);
INSERT INTO public.municipio VALUES (54871, 'VILLA CARO', 54);
INSERT INTO public.municipio VALUES (54874, 'VILLA DEL ROSARIO', 54);
INSERT INTO public.municipio VALUES (63001, 'ARMENIA', 63);
INSERT INTO public.municipio VALUES (63111, 'BUENAVISTA', 63);
INSERT INTO public.municipio VALUES (63130, 'CALARCÁ', 63);
INSERT INTO public.municipio VALUES (63190, 'CIRCASIA', 63);
INSERT INTO public.municipio VALUES (63212, 'CÓRDOBA', 63);
INSERT INTO public.municipio VALUES (63272, 'FILANDIA', 63);
INSERT INTO public.municipio VALUES (63302, 'GÉNOVA', 63);
INSERT INTO public.municipio VALUES (63401, 'LA TEBAIDA', 63);
INSERT INTO public.municipio VALUES (63470, 'MONTENEGRO', 63);
INSERT INTO public.municipio VALUES (63548, 'PIJAO', 63);
INSERT INTO public.municipio VALUES (63594, 'QUIMBAYA', 63);
INSERT INTO public.municipio VALUES (63690, 'SALENTO', 63);
INSERT INTO public.municipio VALUES (66001, 'PEREIRA', 66);
INSERT INTO public.municipio VALUES (66045, 'APÍA', 66);
INSERT INTO public.municipio VALUES (66075, 'BALBOA', 66);
INSERT INTO public.municipio VALUES (66088, 'BELÉN DE UMBRÍA', 66);
INSERT INTO public.municipio VALUES (66170, 'DOSQUEBRADAS', 66);
INSERT INTO public.municipio VALUES (66318, 'GUÁTICA', 66);
INSERT INTO public.municipio VALUES (66383, 'LA CELIA', 66);
INSERT INTO public.municipio VALUES (66400, 'LA VIRGINIA', 66);
INSERT INTO public.municipio VALUES (66440, 'MARSELLA', 66);
INSERT INTO public.municipio VALUES (66456, 'MISTRATÓ', 66);
INSERT INTO public.municipio VALUES (66572, 'PUEBLO RICO', 66);
INSERT INTO public.municipio VALUES (66594, 'QUINCHÍA', 66);
INSERT INTO public.municipio VALUES (66682, 'SANTA ROSA DE CABAL', 66);
INSERT INTO public.municipio VALUES (66687, 'SANTUARIO', 66);
INSERT INTO public.municipio VALUES (68001, 'BUCARAMANGA', 68);
INSERT INTO public.municipio VALUES (68013, 'AGUADA', 68);
INSERT INTO public.municipio VALUES (68020, 'ALBANIA', 68);
INSERT INTO public.municipio VALUES (68051, 'ARATOCA', 68);
INSERT INTO public.municipio VALUES (68077, 'BARBOSA', 68);
INSERT INTO public.municipio VALUES (68079, 'BARICHARA', 68);
INSERT INTO public.municipio VALUES (68081, 'BARRANCABERMEJA', 68);
INSERT INTO public.municipio VALUES (68092, 'BETULIA', 68);
INSERT INTO public.municipio VALUES (68101, 'BOLÍVAR', 68);
INSERT INTO public.municipio VALUES (68121, 'CABRERA', 68);
INSERT INTO public.municipio VALUES (68132, 'CALIFORNIA', 68);
INSERT INTO public.municipio VALUES (68147, 'CAPITANEJO', 68);
INSERT INTO public.municipio VALUES (68152, 'CARCASÍ', 68);
INSERT INTO public.municipio VALUES (68160, 'CEPITÁ', 68);
INSERT INTO public.municipio VALUES (68162, 'CERRITO', 68);
INSERT INTO public.municipio VALUES (68167, 'CHARALÁ', 68);
INSERT INTO public.municipio VALUES (68169, 'CHARTA', 68);
INSERT INTO public.municipio VALUES (68176, 'CHIMA', 68);
INSERT INTO public.municipio VALUES (68179, 'CHIPATÁ', 68);
INSERT INTO public.municipio VALUES (68190, 'CIMITARRA', 68);
INSERT INTO public.municipio VALUES (68207, 'CONCEPCIÓN', 68);
INSERT INTO public.municipio VALUES (68209, 'CONFINES', 68);
INSERT INTO public.municipio VALUES (68211, 'CONTRATACIÓN', 68);
INSERT INTO public.municipio VALUES (68217, 'COROMORO', 68);
INSERT INTO public.municipio VALUES (68229, 'CURITÍ', 68);
INSERT INTO public.municipio VALUES (68235, 'EL CARMEN DE CHUCURÍ', 68);
INSERT INTO public.municipio VALUES (68245, 'EL GUACAMAYO', 68);
INSERT INTO public.municipio VALUES (68250, 'EL PEÑÓN', 68);
INSERT INTO public.municipio VALUES (68255, 'EL PLAYÓN', 68);
INSERT INTO public.municipio VALUES (68264, 'ENCINO', 68);
INSERT INTO public.municipio VALUES (68266, 'ENCISO', 68);
INSERT INTO public.municipio VALUES (68271, 'FLORIÁN', 68);
INSERT INTO public.municipio VALUES (68276, 'FLORIDABLANCA', 68);
INSERT INTO public.municipio VALUES (68296, 'GALÁN', 68);
INSERT INTO public.municipio VALUES (68298, 'GÁMBITA', 68);
INSERT INTO public.municipio VALUES (68307, 'GIRÓN', 68);
INSERT INTO public.municipio VALUES (68318, 'GUACA', 68);
INSERT INTO public.municipio VALUES (68320, 'GUADALUPE', 68);
INSERT INTO public.municipio VALUES (68322, 'GUAPOTÁ', 68);
INSERT INTO public.municipio VALUES (68324, 'GUAVATÁ', 68);
INSERT INTO public.municipio VALUES (68327, 'GÜEPSA', 68);
INSERT INTO public.municipio VALUES (68344, 'HATO', 68);
INSERT INTO public.municipio VALUES (68368, 'JESÚS MARÍA', 68);
INSERT INTO public.municipio VALUES (68370, 'JORDÁN', 68);
INSERT INTO public.municipio VALUES (68377, 'LA BELLEZA', 68);
INSERT INTO public.municipio VALUES (68385, 'LANDÁZURI', 68);
INSERT INTO public.municipio VALUES (68397, 'LA PAZ', 68);
INSERT INTO public.municipio VALUES (68406, 'LEBRIJA', 68);
INSERT INTO public.municipio VALUES (68418, 'LOS SANTOS', 68);
INSERT INTO public.municipio VALUES (68425, 'MACARAVITA', 68);
INSERT INTO public.municipio VALUES (68432, 'MÁLAGA', 68);
INSERT INTO public.municipio VALUES (68444, 'MATANZA', 68);
INSERT INTO public.municipio VALUES (68464, 'MOGOTES', 68);
INSERT INTO public.municipio VALUES (68468, 'MOLAGAVITA', 68);
INSERT INTO public.municipio VALUES (68498, 'OCAMONTE', 68);
INSERT INTO public.municipio VALUES (68500, 'OIBA', 68);
INSERT INTO public.municipio VALUES (68502, 'ONZAGA', 68);
INSERT INTO public.municipio VALUES (68522, 'PALMAR', 68);
INSERT INTO public.municipio VALUES (68524, 'PALMAS DEL SOCORRO', 68);
INSERT INTO public.municipio VALUES (68533, 'PÁRAMO', 68);
INSERT INTO public.municipio VALUES (68547, 'PIEDECUESTA', 68);
INSERT INTO public.municipio VALUES (68549, 'PINCHOTE', 68);
INSERT INTO public.municipio VALUES (68572, 'PUENTE NACIONAL', 68);
INSERT INTO public.municipio VALUES (68573, 'PUERTO PARRA', 68);
INSERT INTO public.municipio VALUES (68575, 'PUERTO WILCHES', 68);
INSERT INTO public.municipio VALUES (68615, 'RIONEGRO', 68);
INSERT INTO public.municipio VALUES (68655, 'SABANA DE TORRES', 68);
INSERT INTO public.municipio VALUES (68669, 'SAN ANDRÉS', 68);
INSERT INTO public.municipio VALUES (68673, 'SAN BENITO', 68);
INSERT INTO public.municipio VALUES (68679, 'SAN GIL', 68);
INSERT INTO public.municipio VALUES (68682, 'SAN JOAQUÍN', 68);
INSERT INTO public.municipio VALUES (68684, 'SAN JOSÉ DE MIRANDA', 68);
INSERT INTO public.municipio VALUES (68686, 'SAN MIGUEL', 68);
INSERT INTO public.municipio VALUES (68689, 'SAN VICENTE DE CHUCURÍ', 68);
INSERT INTO public.municipio VALUES (68705, 'SANTA BÁRBARA', 68);
INSERT INTO public.municipio VALUES (68720, 'SANTA HELENA DEL OPÓN', 68);
INSERT INTO public.municipio VALUES (68745, 'SIMACOTA', 68);
INSERT INTO public.municipio VALUES (68755, 'SOCORRO', 68);
INSERT INTO public.municipio VALUES (68770, 'SUAITA', 68);
INSERT INTO public.municipio VALUES (68773, 'SUCRE', 68);
INSERT INTO public.municipio VALUES (68780, 'SURATÁ', 68);
INSERT INTO public.municipio VALUES (68820, 'TONA', 68);
INSERT INTO public.municipio VALUES (68855, 'VALLE DE SAN JOSÉ', 68);
INSERT INTO public.municipio VALUES (68861, 'VÉLEZ', 68);
INSERT INTO public.municipio VALUES (68867, 'VETAS', 68);
INSERT INTO public.municipio VALUES (68872, 'VILLANUEVA', 68);
INSERT INTO public.municipio VALUES (68895, 'ZAPATOCA', 68);
INSERT INTO public.municipio VALUES (70001, 'SINCELEJO', 70);
INSERT INTO public.municipio VALUES (70110, 'BUENAVISTA', 70);
INSERT INTO public.municipio VALUES (70124, 'CAIMITO', 70);
INSERT INTO public.municipio VALUES (70204, 'COLOSÓ', 70);
INSERT INTO public.municipio VALUES (70215, 'COROZAL', 70);
INSERT INTO public.municipio VALUES (70221, 'COVEÑAS', 70);
INSERT INTO public.municipio VALUES (70230, 'CHALÁN', 70);
INSERT INTO public.municipio VALUES (70233, 'EL ROBLE', 70);
INSERT INTO public.municipio VALUES (70235, 'GALERAS', 70);
INSERT INTO public.municipio VALUES (70265, 'GUARANDA', 70);
INSERT INTO public.municipio VALUES (70400, 'LA UNIÓN', 70);
INSERT INTO public.municipio VALUES (70418, 'LOS PALMITOS', 70);
INSERT INTO public.municipio VALUES (70429, 'MAJAGUAL', 70);
INSERT INTO public.municipio VALUES (70473, 'MORROA', 70);
INSERT INTO public.municipio VALUES (70508, 'OVEJAS', 70);
INSERT INTO public.municipio VALUES (70523, 'PALMITO', 70);
INSERT INTO public.municipio VALUES (70670, 'SAMPUÉS', 70);
INSERT INTO public.municipio VALUES (70678, 'SAN BENITO ABAD', 70);
INSERT INTO public.municipio VALUES (70702, 'SAN JUAN DE BETULIA', 70);
INSERT INTO public.municipio VALUES (70708, 'SAN MARCOS', 70);
INSERT INTO public.municipio VALUES (70713, 'SAN ONOFRE', 70);
INSERT INTO public.municipio VALUES (70717, 'SAN PEDRO', 70);
INSERT INTO public.municipio VALUES (70742, 'SAN LUIS DE SINCÉ', 70);
INSERT INTO public.municipio VALUES (70771, 'SUCRE', 70);
INSERT INTO public.municipio VALUES (70820, 'SANTIAGO DE TOLÚ', 70);
INSERT INTO public.municipio VALUES (70823, 'SAN JOSÉ DE TOLUVIEJO', 70);
INSERT INTO public.municipio VALUES (73001, 'IBAGUÉ', 73);
INSERT INTO public.municipio VALUES (73024, 'ALPUJARRA', 73);
INSERT INTO public.municipio VALUES (73026, 'ALVARADO', 73);
INSERT INTO public.municipio VALUES (73030, 'AMBALEMA', 73);
INSERT INTO public.municipio VALUES (73043, 'ANZOÁTEGUI', 73);
INSERT INTO public.municipio VALUES (73055, 'ARMERO', 73);
INSERT INTO public.municipio VALUES (73067, 'ATACO', 73);
INSERT INTO public.municipio VALUES (73124, 'CAJAMARCA', 73);
INSERT INTO public.municipio VALUES (73148, 'CARMEN DE APICALÁ', 73);
INSERT INTO public.municipio VALUES (73152, 'CASABIANCA', 73);
INSERT INTO public.municipio VALUES (73168, 'CHAPARRAL', 73);
INSERT INTO public.municipio VALUES (73200, 'COELLO', 73);
INSERT INTO public.municipio VALUES (73217, 'COYAIMA', 73);
INSERT INTO public.municipio VALUES (73226, 'CUNDAY', 73);
INSERT INTO public.municipio VALUES (73236, 'DOLORES', 73);
INSERT INTO public.municipio VALUES (73268, 'ESPINAL', 73);
INSERT INTO public.municipio VALUES (73270, 'FALAN', 73);
INSERT INTO public.municipio VALUES (73275, 'FLANDES', 73);
INSERT INTO public.municipio VALUES (73283, 'FRESNO', 73);
INSERT INTO public.municipio VALUES (73319, 'GUAMO', 73);
INSERT INTO public.municipio VALUES (73347, 'HERVEO', 73);
INSERT INTO public.municipio VALUES (73349, 'HONDA', 73);
INSERT INTO public.municipio VALUES (73352, 'ICONONZO', 73);
INSERT INTO public.municipio VALUES (73408, 'LÉRIDA', 73);
INSERT INTO public.municipio VALUES (73411, 'LÍBANO', 73);
INSERT INTO public.municipio VALUES (73443, 'SAN SEBASTIÁN DE MARIQUITA', 73);
INSERT INTO public.municipio VALUES (73449, 'MELGAR', 73);
INSERT INTO public.municipio VALUES (73461, 'MURILLO', 73);
INSERT INTO public.municipio VALUES (73483, 'NATAGAIMA', 73);
INSERT INTO public.municipio VALUES (73504, 'ORTEGA', 73);
INSERT INTO public.municipio VALUES (73520, 'PALOCABILDO', 73);
INSERT INTO public.municipio VALUES (73547, 'PIEDRAS', 73);
INSERT INTO public.municipio VALUES (73555, 'PLANADAS', 73);
INSERT INTO public.municipio VALUES (73563, 'PRADO', 73);
INSERT INTO public.municipio VALUES (73585, 'PURIFICACIÓN', 73);
INSERT INTO public.municipio VALUES (73616, 'RIOBLANCO', 73);
INSERT INTO public.municipio VALUES (73622, 'RONCESVALLES', 73);
INSERT INTO public.municipio VALUES (73624, 'ROVIRA', 73);
INSERT INTO public.municipio VALUES (73671, 'SALDAÑA', 73);
INSERT INTO public.municipio VALUES (73675, 'SAN ANTONIO', 73);
INSERT INTO public.municipio VALUES (73678, 'SAN LUIS', 73);
INSERT INTO public.municipio VALUES (73686, 'SANTA ISABEL', 73);
INSERT INTO public.municipio VALUES (73770, 'SUÁREZ', 73);
INSERT INTO public.municipio VALUES (73854, 'VALLE DE SAN JUAN', 73);
INSERT INTO public.municipio VALUES (73861, 'VENADILLO', 73);
INSERT INTO public.municipio VALUES (73870, 'VILLAHERMOSA', 73);
INSERT INTO public.municipio VALUES (73873, 'VILLARRICA', 73);
INSERT INTO public.municipio VALUES (76001, 'CALI', 76);
INSERT INTO public.municipio VALUES (76020, 'ALCALÁ', 76);
INSERT INTO public.municipio VALUES (76036, 'ANDALUCÍA', 76);
INSERT INTO public.municipio VALUES (76041, 'ANSERMANUEVO', 76);
INSERT INTO public.municipio VALUES (76054, 'ARGELIA', 76);
INSERT INTO public.municipio VALUES (76100, 'BOLÍVAR', 76);
INSERT INTO public.municipio VALUES (76109, 'BUENAVENTURA', 76);
INSERT INTO public.municipio VALUES (76111, 'GUADALAJARA DE BUGA', 76);
INSERT INTO public.municipio VALUES (76113, 'BUGALAGRANDE', 76);
INSERT INTO public.municipio VALUES (76122, 'CAICEDONIA', 76);
INSERT INTO public.municipio VALUES (76126, 'CALIMA', 76);
INSERT INTO public.municipio VALUES (76130, 'CANDELARIA', 76);
INSERT INTO public.municipio VALUES (76147, 'CARTAGO', 76);
INSERT INTO public.municipio VALUES (76233, 'DAGUA', 76);
INSERT INTO public.municipio VALUES (76243, 'EL ÁGUILA', 76);
INSERT INTO public.municipio VALUES (76246, 'EL CAIRO', 76);
INSERT INTO public.municipio VALUES (76248, 'EL CERRITO', 76);
INSERT INTO public.municipio VALUES (76250, 'EL DOVIO', 76);
INSERT INTO public.municipio VALUES (76275, 'FLORIDA', 76);
INSERT INTO public.municipio VALUES (76306, 'GINEBRA', 76);
INSERT INTO public.municipio VALUES (76318, 'GUACARÍ', 76);
INSERT INTO public.municipio VALUES (76364, 'JAMUNDÍ', 76);
INSERT INTO public.municipio VALUES (76377, 'LA CUMBRE', 76);
INSERT INTO public.municipio VALUES (76400, 'LA UNIÓN', 76);
INSERT INTO public.municipio VALUES (76403, 'LA VICTORIA', 76);
INSERT INTO public.municipio VALUES (76497, 'OBANDO', 76);
INSERT INTO public.municipio VALUES (76520, 'PALMIRA', 76);
INSERT INTO public.municipio VALUES (76563, 'PRADERA', 76);
INSERT INTO public.municipio VALUES (76606, 'RESTREPO', 76);
INSERT INTO public.municipio VALUES (76616, 'RIOFRÍO', 76);
INSERT INTO public.municipio VALUES (76622, 'ROLDANILLO', 76);
INSERT INTO public.municipio VALUES (76670, 'SAN PEDRO', 76);
INSERT INTO public.municipio VALUES (76736, 'SEVILLA', 76);
INSERT INTO public.municipio VALUES (76823, 'TORO', 76);
INSERT INTO public.municipio VALUES (76828, 'TRUJILLO', 76);
INSERT INTO public.municipio VALUES (76834, 'TULUÁ', 76);
INSERT INTO public.municipio VALUES (76845, 'ULLOA', 76);
INSERT INTO public.municipio VALUES (76863, 'VERSALLES', 76);
INSERT INTO public.municipio VALUES (76869, 'VIJES', 76);
INSERT INTO public.municipio VALUES (76890, 'YOTOCO', 76);
INSERT INTO public.municipio VALUES (76892, 'YUMBO', 76);
INSERT INTO public.municipio VALUES (76895, 'ZARZAL', 76);
INSERT INTO public.municipio VALUES (81001, 'ARAUCA', 81);
INSERT INTO public.municipio VALUES (81065, 'ARAUQUITA', 81);
INSERT INTO public.municipio VALUES (81220, 'CRAVO NORTE', 81);
INSERT INTO public.municipio VALUES (81300, 'FORTUL', 81);
INSERT INTO public.municipio VALUES (81591, 'PUERTO RONDÓN', 81);
INSERT INTO public.municipio VALUES (81736, 'SARAVENA', 81);
INSERT INTO public.municipio VALUES (81794, 'TAME', 81);
INSERT INTO public.municipio VALUES (85001, 'YOPAL', 85);
INSERT INTO public.municipio VALUES (85010, 'AGUAZUL', 85);
INSERT INTO public.municipio VALUES (85015, 'CHÁMEZA', 85);
INSERT INTO public.municipio VALUES (85125, 'HATO COROZAL', 85);
INSERT INTO public.municipio VALUES (85136, 'LA SALINA', 85);
INSERT INTO public.municipio VALUES (85139, 'MANÍ', 85);
INSERT INTO public.municipio VALUES (85162, 'MONTERREY', 85);
INSERT INTO public.municipio VALUES (85225, 'NUNCHÍA', 85);
INSERT INTO public.municipio VALUES (85230, 'OROCUÉ', 85);
INSERT INTO public.municipio VALUES (85250, 'PAZ DE ARIPORO', 85);
INSERT INTO public.municipio VALUES (85263, 'PORE', 85);
INSERT INTO public.municipio VALUES (85279, 'RECETOR', 85);
INSERT INTO public.municipio VALUES (85300, 'SABANALARGA', 85);
INSERT INTO public.municipio VALUES (85315, 'SÁCAMA', 85);
INSERT INTO public.municipio VALUES (85325, 'SAN LUIS DE PALENQUE', 85);
INSERT INTO public.municipio VALUES (85400, 'TÁMARA', 85);
INSERT INTO public.municipio VALUES (85410, 'TAURAMENA', 85);
INSERT INTO public.municipio VALUES (85430, 'TRINIDAD', 85);
INSERT INTO public.municipio VALUES (85440, 'VILLANUEVA', 85);
INSERT INTO public.municipio VALUES (86001, 'MOCOA', 86);
INSERT INTO public.municipio VALUES (86219, 'COLÓN', 86);
INSERT INTO public.municipio VALUES (86320, 'ORITO', 86);
INSERT INTO public.municipio VALUES (86568, 'PUERTO ASÍS', 86);
INSERT INTO public.municipio VALUES (86569, 'PUERTO CAICEDO', 86);
INSERT INTO public.municipio VALUES (86571, 'PUERTO GUZMÁN', 86);
INSERT INTO public.municipio VALUES (86573, 'PUERTO LEGUÍZAMO', 86);
INSERT INTO public.municipio VALUES (86749, 'SIBUNDOY', 86);
INSERT INTO public.municipio VALUES (86755, 'SAN FRANCISCO', 86);
INSERT INTO public.municipio VALUES (86757, 'SAN MIGUEL', 86);
INSERT INTO public.municipio VALUES (86760, 'SANTIAGO', 86);
INSERT INTO public.municipio VALUES (86865, 'VALLE DEL GUAMUEZ', 86);
INSERT INTO public.municipio VALUES (86885, 'VILLAGARZÓN', 86);
INSERT INTO public.municipio VALUES (88001, 'SAN ANDRÉS', 88);
INSERT INTO public.municipio VALUES (88564, 'PROVIDENCIA', 88);
INSERT INTO public.municipio VALUES (91001, 'LETICIA', 91);
INSERT INTO public.municipio VALUES (91263, 'EL ENCANTO', 91);
INSERT INTO public.municipio VALUES (91405, 'LA CHORRERA', 91);
INSERT INTO public.municipio VALUES (91407, 'LA PEDRERA', 91);
INSERT INTO public.municipio VALUES (91430, 'LA VICTORIA', 91);
INSERT INTO public.municipio VALUES (91460, 'MIRITÍ - PARANÁ', 91);
INSERT INTO public.municipio VALUES (91530, 'PUERTO ALEGRÍA', 91);
INSERT INTO public.municipio VALUES (91536, 'PUERTO ARICA', 91);
INSERT INTO public.municipio VALUES (91540, 'PUERTO NARIÑO', 91);
INSERT INTO public.municipio VALUES (91669, 'PUERTO SANTANDER', 91);
INSERT INTO public.municipio VALUES (91798, 'TARAPACÁ', 91);
INSERT INTO public.municipio VALUES (94001, 'INÍRIDA', 94);
INSERT INTO public.municipio VALUES (94343, 'BARRANCOMINAS', 94);
INSERT INTO public.municipio VALUES (94883, 'SAN FELIPE', 94);
INSERT INTO public.municipio VALUES (94884, 'PUERTO COLOMBIA', 94);
INSERT INTO public.municipio VALUES (94885, 'LA GUADALUPE', 94);
INSERT INTO public.municipio VALUES (94886, 'CACAHUAL', 94);
INSERT INTO public.municipio VALUES (94887, 'PANA PANA', 94);
INSERT INTO public.municipio VALUES (94888, 'MORICHAL', 94);
INSERT INTO public.municipio VALUES (95001, 'SAN JOSÉ DEL GUAVIARE', 95);
INSERT INTO public.municipio VALUES (95015, 'CALAMAR', 95);
INSERT INTO public.municipio VALUES (95025, 'EL RETORNO', 95);
INSERT INTO public.municipio VALUES (95200, 'MIRAFLORES', 95);
INSERT INTO public.municipio VALUES (97001, 'MITÚ', 97);
INSERT INTO public.municipio VALUES (97161, 'CARURÚ', 97);
INSERT INTO public.municipio VALUES (97511, 'PACOA', 97);
INSERT INTO public.municipio VALUES (97666, 'TARAIRA', 97);
INSERT INTO public.municipio VALUES (97777, 'PAPUNAHUA', 97);
INSERT INTO public.municipio VALUES (97889, 'YAVARATÉ', 97);
INSERT INTO public.municipio VALUES (99001, 'PUERTO CARREÑO', 99);
INSERT INTO public.municipio VALUES (99524, 'LA PRIMAVERA', 99);
INSERT INTO public.municipio VALUES (99624, 'SANTA ROSALÍA', 99);
INSERT INTO public.municipio VALUES (99773, 'CUMARIBO', 99);


--
-- TOC entry 3521 (class 0 OID 16711)
-- Dependencies: 214
-- Data for Name: sede; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.sede VALUES (1, 'Sede principal', ' Av Jimenez de Quesada #7a - 17', 6, 11001, true);


--
-- TOC entry 3547 (class 0 OID 16931)
-- Dependencies: 240
-- Data for Name: registroanual; Type: TABLE DATA; Schema: public; Owner: root
--



--
-- TOC entry 3553 (class 0 OID 16974)
-- Dependencies: 246
-- Data for Name: emision; Type: TABLE DATA; Schema: public; Owner: root
--



--
-- TOC entry 3537 (class 0 OID 16808)
-- Dependencies: 230
-- Data for Name: gei; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.gei VALUES (1, 'CO2', 6, true);
INSERT INTO public.gei VALUES (2, 'CH4', 6, true);
INSERT INTO public.gei VALUES (3, 'N2O', 6, true);
INSERT INTO public.gei VALUES (4, 'HFC-32', 6, true);
INSERT INTO public.gei VALUES (5, 'HFC-125', 6, true);
INSERT INTO public.gei VALUES (6, 'HFC-134a', 6, true);
INSERT INTO public.gei VALUES (7, 'HFC-143a', 6, true);
INSERT INTO public.gei VALUES (8, 'HFC-152a', 6, true);
INSERT INTO public.gei VALUES (9, 'HFC-227ea', 6, true);
INSERT INTO public.gei VALUES (10, 'PFCs', 6, true);
INSERT INTO public.gei VALUES (11, 'SF6', 6, true);
INSERT INTO public.gei VALUES (12, 'R-123', 6, true);
INSERT INTO public.gei VALUES (13, 'Otros compuestos', 6, true);


--
-- TOC entry 3545 (class 0 OID 16909)
-- Dependencies: 238
-- Data for Name: factoremision; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.factoremision VALUES (1, 10.14900000, 1.00000000, 0.210, 0.210, 1, 6, 1, true);
INSERT INTO public.factoremision VALUES (2, 0.00013680, 28.00000000, 1.000, 10.000, 2, 6, 1, true);
INSERT INTO public.factoremision VALUES (3, 0.00008210, 265.00000000, 0.200, 2.000, 3, 6, 1, true);
INSERT INTO public.factoremision VALUES (4, 8.80850000, 1.00000000, 0.200, 0.200, 1, 6, 2, true);
INSERT INTO public.factoremision VALUES (5, 0.00038120, 28.00000000, 1.000, 10.000, 2, 6, 2, true);
INSERT INTO public.factoremision VALUES (6, 0.00007620, 265.00000000, 0.200, 2.000, 3, 6, 2, true);
INSERT INTO public.factoremision VALUES (7, 10.27650000, 1.00000000, 0.210, 0.210, 1, 6, 3, true);
INSERT INTO public.factoremision VALUES (8, 0.00040710, 28.00000000, 1.000, 10.000, 2, 6, 3, true);
INSERT INTO public.factoremision VALUES (9, 0.00008140, 265.00000000, 0.200, 2.000, 3, 6, 3, true);
INSERT INTO public.factoremision VALUES (10, 7.61810000, 1.00000000, 0.230, 0.230, 1, 6, 4, true);
INSERT INTO public.factoremision VALUES (11, 0.00034220, 28.00000000, 1.000, 10.000, 2, 6, 4, true);
INSERT INTO public.factoremision VALUES (12, 0.00006840, 265.00000000, 0.200, 2.000, 3, 6, 4, true);
INSERT INTO public.factoremision VALUES (13, 1.98009060, 1.00000000, 6.590, 6.590, 1, 6, 5, true);
INSERT INTO public.factoremision VALUES (14, 0.00003570, 28.00000000, 0.300, 3.000, 2, 6, 5, true);
INSERT INTO public.factoremision VALUES (15, 0.00000360, 265.00000000, 0.030, 3.000, 3, 6, 5, true);
INSERT INTO public.factoremision VALUES (78, 2.33000000, 1.00000000, 1.000, 50.000, 1, 6, 61, true);
INSERT INTO public.factoremision VALUES (28, 1.98009060, 1.00000000, 6.590, 6.590, 1, 6, 10, true);
INSERT INTO public.factoremision VALUES (18, 0.00053350, 265.00000000, 1.300, 12.000, 3, 6, 6, true);
INSERT INTO public.factoremision VALUES (17, 0.00053350, 28.00000000, 1.600, 9.500, 2, 6, 6, true);
INSERT INTO public.factoremision VALUES (16, 10.14900000, 1.00000000, 0.210, 0.210, 1, 6, 6, true);
INSERT INTO public.factoremision VALUES (21, 0.00040660, 265.00000000, 0.960, 11.000, 3, 6, 7, true);
INSERT INTO public.factoremision VALUES (20, 0.00419310, 28.00000000, 9.600, 110.000, 2, 6, 7, true);
INSERT INTO public.factoremision VALUES (19, 8.80850000, 1.00000000, 0.200, 0.200, 1, 6, 7, true);
INSERT INTO public.factoremision VALUES (24, 0.00052920, 265.00000000, 1.300, 12.000, 3, 6, 8, true);
INSERT INTO public.factoremision VALUES (23, 0.00052920, 28.00000000, 1.600, 9.500, 2, 6, 8, true);
INSERT INTO public.factoremision VALUES (79, 1.81000000, 1.00000000, 1.000, 50.000, 1, 6, 35, true);
INSERT INTO public.factoremision VALUES (22, 10.27650000, 1.00000000, 0.210, 0.210, 1, 6, 8, true);
INSERT INTO public.factoremision VALUES (27, 0.00036510, 265.00000000, 0.960, 11.000, 3, 6, 9, true);
INSERT INTO public.factoremision VALUES (26, 0.00376460, 28.00000000, 9.600, 110.000, 2, 6, 9, true);
INSERT INTO public.factoremision VALUES (25, 7.61810000, 1.00000000, 0.230, 0.230, 1, 6, 9, true);
INSERT INTO public.factoremision VALUES (29, 0.00328000, 28.00000000, 50.000, 154.000, 2, 6, 10, true);
INSERT INTO public.factoremision VALUES (30, 0.00010700, 265.00000000, 1.000, 77.000, 3, 6, 10, true);
INSERT INTO public.factoremision VALUES (31, 1.95735810, 1.00000000, 1.000, 50.000, 1, 6, 11, true);
INSERT INTO public.factoremision VALUES (32, 0.14740000, 1.00000000, 1.000, 50.000, 1, 6, 12, true);
INSERT INTO public.factoremision VALUES (33, 1.00000000, 1.00000000, 1.000, 50.000, 1, 6, 13, true);
INSERT INTO public.factoremision VALUES (34, 79.00000000, 1.00000000, 1.000, 50.000, 12, 6, 14, true);
INSERT INTO public.factoremision VALUES (35, 677.00000000, 1.00000000, 1.000, 50.000, 4, 6, 15, true);
INSERT INTO public.factoremision VALUES (36, 3170.00000000, 1.00000000, 1.000, 50.000, 5, 6, 16, true);
INSERT INTO public.factoremision VALUES (37, 1300.00000000, 1.00000000, 1.000, 50.000, 6, 6, 17, true);
INSERT INTO public.factoremision VALUES (38, 138.00000000, 1.00000000, 1.000, 50.000, 8, 6, 18, true);
INSERT INTO public.factoremision VALUES (39, 4800.00000000, 1.00000000, 1.000, 50.000, 7, 6, 19, true);
INSERT INTO public.factoremision VALUES (40, 3350.00000000, 1.00000000, 1.000, 50.000, 9, 6, 20, true);
INSERT INTO public.factoremision VALUES (41, 6630.00000000, 1.00000000, 1.000, 50.000, 10, 6, 21, true);
INSERT INTO public.factoremision VALUES (42, 23500.00000000, 1.00000000, 1.000, 50.000, 11, 6, 22, true);
INSERT INTO public.factoremision VALUES (43, 4660.00000000, 1.00000000, 1.000, 50.000, 13, 6, 46, true);
INSERT INTO public.factoremision VALUES (44, 10200.00000000, 1.00000000, 1.000, 50.000, 13, 6, 47, true);
INSERT INTO public.factoremision VALUES (45, 1760.00000000, 1.00000000, 1.000, 50.000, 13, 6, 25, true);
INSERT INTO public.factoremision VALUES (46, 782.00000000, 1.00000000, 1.000, 50.000, 13, 6, 48, true);
INSERT INTO public.factoremision VALUES (47, 12400.00000000, 1.00000000, 1.000, 50.000, 13, 6, 49, true);
INSERT INTO public.factoremision VALUES (48, 1120.00000000, 1.00000000, 1.000, 50.000, 13, 6, 26, true);
INSERT INTO public.factoremision VALUES (49, 328.00000000, 1.00000000, 1.000, 50.000, 13, 6, 50, true);
INSERT INTO public.factoremision VALUES (50, 3943.00000000, 1.00000000, 1.000, 50.000, 13, 6, 27, true);
INSERT INTO public.factoremision VALUES (51, 1624.00000000, 1.00000000, 1.000, 50.000, 13, 6, 23, true);
INSERT INTO public.factoremision VALUES (52, 1924.00000000, 1.00000000, 1.000, 50.000, 1, 6, 24, true);
INSERT INTO public.factoremision VALUES (53, 2473.00000000, 1.00000000, 1.000, 50.000, 13, 6, 51, true);
INSERT INTO public.factoremision VALUES (54, 3.00000000, 1.00000000, 1.000, 50.000, 13, 6, 52, true);
INSERT INTO public.factoremision VALUES (55, 6290.00000000, 1.00000000, 1.000, 50.000, 13, 6, 53, true);
INSERT INTO public.factoremision VALUES (56, 0.20300000, 1.00000000, 5.000, 10.000, 1, 6, 28, true);
INSERT INTO public.factoremision VALUES (57, 1.00000000, 1.00000000, 5.000, 5.000, 1, 6, 29, true);
INSERT INTO public.factoremision VALUES (58, 0.50745000, 1.00000000, 0.210, 0.210, 1, 6, 30, true);
INSERT INTO public.factoremision VALUES (59, 0.00002670, 28.00000000, 1.000, 10.000, 2, 6, 30, true);
INSERT INTO public.factoremision VALUES (60, 0.00002670, 265.00000000, 0.200, 2.000, 3, 6, 30, true);
INSERT INTO public.factoremision VALUES (61, 0.30377590, 1.00000000, 0.200, 0.200, 1, 6, 31, true);
INSERT INTO public.factoremision VALUES (62, 0.00014460, 28.00000000, 1.000, 10.000, 2, 6, 31, true);
INSERT INTO public.factoremision VALUES (63, 0.00001400, 265.00000000, 0.200, 2.000, 3, 6, 31, true);
INSERT INTO public.factoremision VALUES (64, 0.51382500, 1.00000000, 0.210, 0.210, 1, 6, 32, true);
INSERT INTO public.factoremision VALUES (65, 0.00002710, 28.00000000, 1.000, 10.000, 2, 6, 32, true);
INSERT INTO public.factoremision VALUES (66, 0.00002710, 265.00000000, 0.200, 2.000, 3, 6, 32, true);
INSERT INTO public.factoremision VALUES (67, 0.26269310, 1.00000000, 0.230, 0.230, 1, 6, 33, true);
INSERT INTO public.factoremision VALUES (68, 0.00012980, 28.00000000, 1.000, 10.000, 2, 6, 33, true);
INSERT INTO public.factoremision VALUES (69, 0.00001260, 265.00000000, 0.200, 2.000, 3, 6, 33, true);
INSERT INTO public.factoremision VALUES (70, 1.05000000, 1.00000000, 1.000, 50.000, 1, 6, 34, true);
INSERT INTO public.factoremision VALUES (71, 0.81000000, 1.00000000, 1.000, 50.000, 1, 6, 54, true);
INSERT INTO public.factoremision VALUES (72, 0.83000000, 1.00000000, 1.000, 50.000, 1, 6, 55, true);
INSERT INTO public.factoremision VALUES (73, 1.39000000, 1.00000000, 1.000, 50.000, 1, 6, 56, true);
INSERT INTO public.factoremision VALUES (74, 2.87000000, 1.00000000, 1.000, 50.000, 1, 6, 57, true);
INSERT INTO public.factoremision VALUES (75, 2.08000000, 1.00000000, 1.000, 50.000, 1, 6, 58, true);
INSERT INTO public.factoremision VALUES (76, 2.89000000, 1.00000000, 1.000, 50.000, 1, 6, 59, true);
INSERT INTO public.factoremision VALUES (77, 11.10000000, 1.00000000, 1.000, 50.000, 1, 6, 60, true);
INSERT INTO public.factoremision VALUES (80, 0.07282990, 28.00000000, 5.000, 30.000, 2, 6, 36, true);
INSERT INTO public.factoremision VALUES (81, 1.48500000, 1.00000000, 1.000, 100.000, 1, 6, 37, true);
INSERT INTO public.factoremision VALUES (82, 0.08484820, 28.00000000, 58.000, 133.330, 2, 6, 38, true);
INSERT INTO public.factoremision VALUES (83, 0.05090890, 28.00000000, 42.000, 150.000, 2, 6, 62, true);
INSERT INTO public.factoremision VALUES (84, 0.07800000, 1.00000000, 1.000, 16.000, 1, 6, 39, true);
INSERT INTO public.factoremision VALUES (85, 6.88230000, 1.00000000, 0.300, 0.300, 1, 6, 40, true);
INSERT INTO public.factoremision VALUES (86, 0.00037670, 28.00000000, 1.000, 10.000, 2, 6, 40, true);
INSERT INTO public.factoremision VALUES (87, 0.00007530, 265.00000000, 0.200, 2.000, 3, 6, 40, true);
INSERT INTO public.factoremision VALUES (88, 5.92010000, 1.00000000, 0.350, 0.350, 1, 6, 41, true);
INSERT INTO public.factoremision VALUES (89, 0.00020950, 28.00000000, 1.000, 10.000, 2, 6, 41, true);
INSERT INTO public.factoremision VALUES (90, 0.00004190, 265.00000000, 0.200, 2.000, 3, 6, 41, true);
INSERT INTO public.factoremision VALUES (91, 1.85602560, 1.00000000, 8.890, 8.890, 1, 6, 42, true);
INSERT INTO public.factoremision VALUES (92, 0.00002200, 28.00000000, 0.300, 3.000, 2, 6, 42, true);
INSERT INTO public.factoremision VALUES (93, 0.00000220, 265.00000000, 0.030, 3.000, 3, 6, 42, true);
INSERT INTO public.factoremision VALUES (94, 6.88230000, 1.00000000, 0.300, 0.300, 1, 6, 43, true);
INSERT INTO public.factoremision VALUES (95, 0.00048970, 28.00000000, 1.600, 9.500, 2, 6, 43, true);
INSERT INTO public.factoremision VALUES (96, 0.00048970, 265.00000000, 1.300, 12.000, 3, 6, 43, true);
INSERT INTO public.factoremision VALUES (97, 5.92010000, 1.00000000, 0.350, 0.350, 1, 6, 44, true);
INSERT INTO public.factoremision VALUES (98, 0.01816030, 28.00000000, 13.000, 84.000, 2, 6, 44, true);
INSERT INTO public.factoremision VALUES (99, 0.00286370, 265.00000000, 13.000, 123.000, 3, 6, 44, true);
INSERT INTO public.factoremision VALUES (100, 1.85602560, 1.00000000, 8.890, 8.890, 1, 6, 45, true);
INSERT INTO public.factoremision VALUES (101, 0.00202400, 28.00000000, 0.300, 3.000, 2, 6, 45, true);
INSERT INTO public.factoremision VALUES (102, 0.00006600, 265.00000000, 0.030, 3.000, 3, 6, 45, true);


--
-- TOC entry 3549 (class 0 OID 16948)
-- Dependencies: 242
-- Data for Name: emisiongei; Type: TABLE DATA; Schema: public; Owner: root
--



--
-- TOC entry 3551 (class 0 OID 16960)
-- Dependencies: 244
-- Data for Name: log; Type: TABLE DATA; Schema: public; Owner: root
--



--
-- TOC entry 3543 (class 0 OID 16887)
-- Dependencies: 236
-- Data for Name: registroactividad; Type: TABLE DATA; Schema: public; Owner: root
--



--
-- TOC entry 3557 (class 0 OID 98942)
-- Dependencies: 250
-- Data for Name: reporte; Type: TABLE DATA; Schema: public; Owner: root
--

INSERT INTO public.reporte VALUES (1, 'Reporte barras emisiones de alcances y biocombustibles', 'https://app.powerbi.com/view?r=eyJrIjoiOGNjNmNiZDAtODc0OS00NzEwLWI1NTgtN2EzOTZiZmRhNWJkIiwidCI6IjZhZmEwZTAwLWZhMTQtNDBiNy04YTJlLTIyYTdmOGMzNTdkNSIsImMiOjh9');
INSERT INTO public.reporte VALUES (2, 'Reporte tablas emisiones de alcances y biocombustibles', 'https://app.powerbi.com/view?r=eyJrIjoiY2YyZDk3ZjItOGVlMS00MDQyLTlmYTEtMDc3NGQwZjQ0MTQ2IiwidCI6IjZhZmEwZTAwLWZhMTQtNDBiNy04YTJlLTIyYTdmOGMzNTdkNSIsImMiOjh9');
INSERT INTO public.reporte VALUES (3, 'Reporte emisiones de cada GEI', 'https://app.powerbi.com/view?r=eyJrIjoiNDI1M2I2NDQtZTBhMy00NTA5LWE0NjMtZjZkYjg4ZGE1YzY0IiwidCI6IjZhZmEwZTAwLWZhMTQtNDBiNy04YTJlLTIyYTdmOGMzNTdkNSIsImMiOjh9');
INSERT INTO public.reporte VALUES (4, 'Reporte de Logs', 'https://app.powerbi.com/view?r=eyJrIjoiYTgzNDYzMWMtZmZmNS00YjFiLTgwMTMtMmM1NzlhYzczNTNjIiwidCI6IjZhZmEwZTAwLWZhMTQtNDBiNy04YTJlLTIyYTdmOGMzNTdkNSIsImMiOjh9');
INSERT INTO public.reporte VALUES (5, 'Reporte de datos faltantes', 'https://app.powerbi.com/view?r=eyJrIjoiMDkxZmE0ZmQtNmMxNC00YTgxLWFhMjQtOWE5MzNlMDUzNjc1IiwidCI6IjZhZmEwZTAwLWZhMTQtNDBiNy04YTJlLTIyYTdmOGMzNTdkNSIsImMiOjh9');


--
-- TOC entry 3563 (class 0 OID 0)
-- Dependencies: 215
-- Name: alcance_idalcance_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.alcance_idalcance_seq', 4, true);


--
-- TOC entry 3564 (class 0 OID 0)
-- Dependencies: 217
-- Name: categoria_idcategoria_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.categoria_idcategoria_seq', 9, true);


--
-- TOC entry 3565 (class 0 OID 0)
-- Dependencies: 231
-- Name: combustible_idcombustible_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.combustible_idcombustible_seq', 54, true);


--
-- TOC entry 3566 (class 0 OID 0)
-- Dependencies: 233
-- Name: configuracionactividad_idconfiguracion_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.configuracionactividad_idconfiguracion_seq', 65, true);


--
-- TOC entry 3567 (class 0 OID 0)
-- Dependencies: 245
-- Name: emision_idemision_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.emision_idemision_seq', 139, true);


--
-- TOC entry 3568 (class 0 OID 0)
-- Dependencies: 241
-- Name: emisiongei_idemisiongei_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.emisiongei_idemisiongei_seq', 264, true);


--
-- TOC entry 3569 (class 0 OID 0)
-- Dependencies: 237
-- Name: factoremision_idfe_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.factoremision_idfe_seq', 102, true);


--
-- TOC entry 3570 (class 0 OID 0)
-- Dependencies: 221
-- Name: fuenteemision_ifduenteemision_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.fuenteemision_ifduenteemision_seq', 8, true);


--
-- TOC entry 3571 (class 0 OID 0)
-- Dependencies: 229
-- Name: gei_idgei_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.gei_idgei_seq', 13, true);


--
-- TOC entry 3572 (class 0 OID 0)
-- Dependencies: 243
-- Name: log_idlog_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.log_idlog_seq', 776, true);


--
-- TOC entry 3573 (class 0 OID 0)
-- Dependencies: 235
-- Name: registroactividad_idregistroactividad_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.registroactividad_idregistroactividad_seq', 1199, true);


--
-- TOC entry 3574 (class 0 OID 0)
-- Dependencies: 239
-- Name: registroanual_idregistroanual_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.registroanual_idregistroanual_seq', 14, true);


--
-- TOC entry 3575 (class 0 OID 0)
-- Dependencies: 249
-- Name: reportes_idreportes_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.reportes_idreportes_seq', 5, true);


--
-- TOC entry 3576 (class 0 OID 0)
-- Dependencies: 209
-- Name: rol_idrol_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.rol_idrol_seq', 7, true);


--
-- TOC entry 3577 (class 0 OID 0)
-- Dependencies: 213
-- Name: sede_idsede_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.sede_idsede_seq', 2, true);


--
-- TOC entry 3578 (class 0 OID 0)
-- Dependencies: 219
-- Name: subcategoria_idsubcategoria_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.subcategoria_idsubcategoria_seq', 16, true);


--
-- TOC entry 3579 (class 0 OID 0)
-- Dependencies: 227
-- Name: tipo_idtipo_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.tipo_idtipo_seq', 4, true);


--
-- TOC entry 3580 (class 0 OID 0)
-- Dependencies: 223
-- Name: tipoactividad_idtipoactividad_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.tipoactividad_idtipoactividad_seq', 12, true);


--
-- TOC entry 3581 (class 0 OID 0)
-- Dependencies: 225
-- Name: unidad_idunidad_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.unidad_idunidad_seq', 8, false);


--
-- TOC entry 3582 (class 0 OID 0)
-- Dependencies: 211
-- Name: usuario_idusuario_seq; Type: SEQUENCE SET; Schema: public; Owner: root
--

SELECT pg_catalog.setval('public.usuario_idusuario_seq', 1, true);


-- Completed on 2022-12-01 19:37:05 UTC

--
-- PostgreSQL database dump complete
--

