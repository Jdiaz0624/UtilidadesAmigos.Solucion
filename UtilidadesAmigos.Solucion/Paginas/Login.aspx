<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Acceso Corporativo – Futuro Seguros</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:wght@600;700;800&family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<style>
/* ══════════════════════════════════════════════════
   TOKENS — paleta propia "Futuro" (azul institucional)
   Estructura visual inspirada en DSSeguros, colores propios.
══════════════════════════════════════════════════ */
:root {
    --navy:        #0A1830;
    --navy-2:      #0F2340;
    --navy-3:      #16304F;
    --navy-4:      #1D3B5C;
    --blue:        #2E9CCA;
    --blue-light:  #6CC5E8;
    --blue-dim:    rgba(46,156,202,0.18);
    --blue-glow:   rgba(46,156,202,0.28);
    --text-bright: #EEF3F8;
    --text-mid:    #9FB1C4;
    --text-dim:    #566E88;
    --border:      rgba(46,156,202,0.16);
    --border-dim:  rgba(255,255,255,0.05);
    --danger:      #E05454;
    --success:     #3DAA72;
    --radius-lg:   18px;
    --radius-md:   12px;
    --radius-sm:   8px;
    --transition:  0.22s cubic-bezier(.4,0,.2,1);
}

*, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

body, html {
    height: 100%;
    font-family: 'Inter', sans-serif;
    background: var(--navy);
    color: var(--text-bright);
    overflow: hidden;
}

/* ══════════════════════════════════════════════════
   FONDO
══════════════════════════════════════════════════ */
.hl-bg {
    position: fixed; inset: 0; z-index: 0;
    background:
        radial-gradient(ellipse at 0% 100%, rgba(46,156,202,0.06) 0%, transparent 55%),
        radial-gradient(ellipse at 100% 0%, rgba(20,45,75,0.65) 0%, transparent 60%),
        var(--navy);
}

/* Retícula de datos / red — evoca reportería y trazabilidad */
.hl-topo {
    position: fixed; inset: 0; z-index: 0; pointer-events: none; overflow: hidden;
    opacity: 0.05;
}
.hl-topo svg { width: 100%; height: 100%; }

/* ══════════════════════════════════════════════════
   LAYOUT SPLIT
══════════════════════════════════════════════════ */
.hl-shell {
    position: relative; z-index: 10;
    min-height: 100vh;
    display: grid;
    grid-template-columns: 1fr 1fr;
}

/* ── PANEL IZQUIERDO ── */
.hl-left {
    background:
        linear-gradient(160deg, rgba(46,156,202,0.07) 0%, transparent 50%),
        var(--navy-2);
    border-right: 1px solid var(--border);
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 52px 56px;
    position: relative;
    overflow: hidden;
}

.hl-left::before {
    content: '';
    position: absolute; inset: 0;
    background-image:
        repeating-linear-gradient(
            -45deg,
            transparent,
            transparent 48px,
            rgba(46,156,202,0.025) 49px,
            transparent 50px
        );
    pointer-events: none;
}

.hl-left::after {
    content: '';
    position: absolute; top: 0; left: 0;
    width: 220px; height: 3px;
    background: linear-gradient(90deg, var(--blue), transparent);
}

/* Logo / marca */
.hl-logo {
    display: flex;
    align-items: center;
    gap: 14px;
}

.hl-logo-icon {
    width: 46px; height: 46px;
    border-radius: 10px;
    overflow: hidden;
    display: flex; align-items: center; justify-content: center;
    background: #fff;
    border: 1.5px solid rgba(46,156,202,0.5);
    flex-shrink: 0;
}

.hl-logo-icon img {
    max-width: 100%; max-height: 100%;
    object-fit: contain;
}

.hl-logo-text { display: flex; flex-direction: column; }

.hl-logo-name {
    font-family: 'Playfair Display', serif;
    font-size: 17px; font-weight: 700;
    color: var(--text-bright);
    letter-spacing: 0.01em;
    line-height: 1.15;
}

.hl-logo-tagline {
    font-size: 10px; font-weight: 500;
    color: var(--blue-light);
    text-transform: uppercase;
    letter-spacing: 0.14em;
    margin-top: 3px;
}

/* ── ÍCONO CENTRAL: Panel de reportería / utilidades animado ── */
.hl-panel-wrap {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0;
    flex: 1;
    justify-content: center;
}

.hl-panel-svg {
    width: 168px; height: 168px;
    filter: drop-shadow(0 0 26px rgba(46,156,202,0.22));
    transition: filter var(--transition);
}

.hl-panel-svg.active {
    filter: drop-shadow(0 0 42px rgba(46,156,202,0.48));
    animation: panelPulse 2s ease-in-out infinite;
}

@keyframes panelPulse {
    0%,100% { filter: drop-shadow(0 0 26px rgba(46,156,202,0.30)); }
    50%      { filter: drop-shadow(0 0 48px rgba(46,156,202,0.55)); }
}

/* Marco del dashboard — se dibuja */
.pnl-frame {
    stroke-dasharray: 460;
    stroke-dashoffset: 460;
    animation: drawPanel 1.4s cubic-bezier(.4,0,.2,1) 0.2s forwards;
}

/* Barras del reporte — crecen desde la base */
.pnl-bar {
    transform-box: fill-box;
    transform-origin: bottom;
    transform: scaleY(0);
    animation: growBar 0.6s cubic-bezier(.34,1.56,.64,1) forwards;
}
.pnl-bar1 { animation-delay: 0.9s; }
.pnl-bar2 { animation-delay: 1.05s; }
.pnl-bar3 { animation-delay: 1.2s; }
.pnl-bar4 { animation-delay: 1.35s; }

/* Línea de tendencia — se dibuja al final */
.pnl-trend {
    stroke-dasharray: 140;
    stroke-dashoffset: 140;
    animation: drawPanel 0.9s cubic-bezier(.4,0,.2,1) 1.6s forwards;
}

.pnl-trend-dot {
    opacity: 0;
    animation: dotIn 0.4s ease 2.4s forwards;
}

/* Engranaje — utilidades / procesos, rotación continua suave */
.pnl-gear {
    transform-box: fill-box;
    transform-origin: center;
    animation: gearSpin 9s linear infinite;
    opacity: 0;
    animation: gearSpin 9s linear infinite, gearIn 0.5s ease 0.4s forwards;
}

@keyframes drawPanel { to { stroke-dashoffset: 0; } }
@keyframes growBar { to { transform: scaleY(1); } }
@keyframes dotIn { to { opacity: 1; } }
@keyframes gearIn { to { opacity: 1; } }
@keyframes gearSpin { from { transform: rotate(0deg); } to { transform: rotate(360deg); } }

/* Claim rotante */
.hl-claim-wrap {
    margin-top: 34px;
    text-align: center;
    height: 56px;
    position: relative;
    overflow: hidden;
}

.hl-claim-item {
    position: absolute; inset: 0;
    display: flex; flex-direction: column;
    align-items: center; justify-content: center;
    opacity: 0;
    transform: translateY(12px);
    transition: opacity 0.6s ease, transform 0.6s ease;
}

.hl-claim-item.visible {
    opacity: 1;
    transform: translateY(0);
}

.hl-claim-word {
    font-family: 'Playfair Display', serif;
    font-size: 27px; font-weight: 700;
    color: var(--blue-light);
    letter-spacing: 0.01em;
    line-height: 1;
}

.hl-claim-sub {
    font-size: 11px; font-weight: 500;
    color: var(--text-dim);
    text-transform: uppercase;
    letter-spacing: 0.1em;
    margin-top: 6px;
}

/* Pilares en la base */
.hl-pillars {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 1px;
    background: var(--border);
    border: 1px solid var(--border);
    border-radius: var(--radius-md);
    overflow: hidden;
}

.hl-pillar {
    background: var(--navy-2);
    padding: 16px 14px;
    text-align: center;
}

.hl-pillar-num {
    font-family: 'Inter', sans-serif;
    font-size: 20px; font-weight: 700;
    color: var(--blue-light);
    letter-spacing: -0.02em;
    line-height: 1;
}

.hl-pillar-label {
    font-size: 10px; font-weight: 500;
    color: var(--text-dim);
    text-transform: uppercase;
    letter-spacing: 0.08em;
    margin-top: 4px;
}

/* ── PANEL DERECHO ── */
.hl-right {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 40px 56px;
    position: relative;
    overflow-y: auto;
}

.hl-right::before {
    content: '';
    position: absolute;
    top: 50%; left: 50%;
    transform: translate(-50%, -50%);
    width: 400px; height: 400px;
    border-radius: 50%;
    background: radial-gradient(circle, rgba(46,156,202,0.05) 0%, transparent 70%);
    pointer-events: none;
}

.hl-form-box {
    width: 100%;
    max-width: 400px;
    animation: panelIn 0.5s cubic-bezier(.22,.68,0,1.1) both;
}

@keyframes panelIn {
    from { opacity: 0; transform: translateY(24px); }
    to   { opacity: 1; transform: translateY(0); }
}

.hl-form-header { margin-bottom: 32px; }

.hl-form-eyebrow {
    font-size: 10px; font-weight: 700;
    text-transform: uppercase;
    letter-spacing: 0.14em;
    color: var(--blue);
    margin-bottom: 8px;
    display: flex; align-items: center; gap: 8px;
}

.hl-form-eyebrow::before {
    content: '';
    display: block;
    width: 24px; height: 1.5px;
    background: var(--blue);
}

.hl-form-title {
    font-family: 'Playfair Display', serif;
    font-size: 29px; font-weight: 700;
    color: var(--text-bright);
    letter-spacing: -0.01em;
    line-height: 1.2;
    margin-bottom: 8px;
}

.hl-form-desc {
    font-size: 13px; font-weight: 400;
    color: var(--text-mid);
    line-height: 1.6;
}

/* ── CAMPOS ── */
.hl-field { margin-bottom: 18px; }

.hl-field-label { margin-bottom: 8px; }

.hl-field-label span {
    font-size: 11px; font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 0.08em;
    color: var(--text-mid);
}

.hl-input-wrap { position: relative; }

.hl-input-icon {
    position: absolute;
    left: 16px; top: 50%;
    transform: translateY(-50%);
    color: var(--text-dim);
    font-size: 14px;
    pointer-events: none;
    transition: color var(--transition);
    z-index: 1;
}

.hl-input {
    width: 100% !important;
    background: var(--navy-3) !important;
    color: var(--text-bright) !important;
    border: 1.5px solid rgba(255,255,255,0.08) !important;
    border-radius: var(--radius-md) !important;
    padding: 12px 16px 12px 46px !important;
    font-size: 14px !important;
    font-family: 'Inter', sans-serif !important;
    font-weight: 400 !important;
    transition: border-color var(--transition), box-shadow var(--transition), background var(--transition) !important;
    outline: none !important;
    -webkit-text-fill-color: var(--text-bright);
}

.hl-input::placeholder {
    color: var(--text-dim) !important;
    font-weight: 300 !important;
}

.hl-input:focus {
    border-color: var(--blue) !important;
    background: var(--navy-4) !important;
    box-shadow: 0 0 0 3px var(--blue-dim) !important;
    -webkit-text-fill-color: var(--text-bright);
}

.hl-input:-webkit-autofill,
.hl-input:-webkit-autofill:focus {
    -webkit-box-shadow: 0 0 0 1000px #16304F inset !important;
    -webkit-text-fill-color: var(--text-bright) !important;
}

/* ── DIVISOR ── */
.hl-divider {
    height: 1px;
    background: linear-gradient(90deg, transparent, var(--border), transparent);
    margin: 26px 0;
}

.hl-divider-label {
    text-align: center;
    font-size: 10px;
    font-weight: 700;
    text-transform: uppercase;
    letter-spacing: 0.12em;
    color: var(--text-dim);
    margin: 20px 0 14px;
}

/* ── BOTONES DE ACCIÓN (imágenes) ── */
.hl-actions {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 28px;
    margin-top: 6px;
}

.hl-action {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 10px;
}

.hl-action-btn-wrap {
    width: 64px; height: 64px;
    border-radius: 50%;
    background: linear-gradient(160deg, var(--navy-4), var(--navy-3));
    border: 1.5px solid rgba(46,156,202,0.35);
    display: flex; align-items: center; justify-content: center;
    box-shadow: 0 6px 20px rgba(0,0,0,0.35), 0 0 0 1px rgba(255,255,255,0.02) inset;
    transition: transform var(--transition), box-shadow var(--transition), border-color var(--transition);
}

.hl-action-btn-wrap:hover {
    transform: translateY(-3px);
    border-color: var(--blue);
    box-shadow: 0 10px 28px rgba(46,156,202,0.30), 0 0 0 1px rgba(255,255,255,0.03) inset;
}

.hl-action-btn-wrap.primario {
    background: linear-gradient(150deg, #1A6E90 0%, var(--blue) 55%, var(--blue-light) 100%);
    border-color: rgba(108,197,232,0.6);
    box-shadow: 0 6px 22px rgba(46,156,202,0.35);
}

.hl-action-btn-wrap.primario:hover {
    box-shadow: 0 12px 32px rgba(46,156,202,0.5);
}

.BotonImagen {
    width: 26px !important;
    height: 26px !important;
    border: none;
    background: transparent;
    filter: brightness(0) invert(1);
    opacity: 0.92;
    transition: transform var(--transition);
}

.hl-action-btn-wrap:hover .BotonImagen { transform: scale(1.12); }

.hl-action-label {
    font-size: 11px;
    font-weight: 600;
    color: var(--text-mid);
    text-transform: uppercase;
    letter-spacing: 0.05em;
}

/* ── FOOTER DEL FORM ── */
.hl-form-footer {
    margin-top: 26px;
    text-align: center;
    font-size: 11px;
    color: var(--text-dim);
    line-height: 1.7;
}

.hl-security-badge {
    display: inline-flex;
    align-items: center;
    gap: 6px;
    font-size: 10px;
    font-weight: 600;
    color: var(--text-dim);
    letter-spacing: 0.06em;
    text-transform: uppercase;
    margin-top: 10px;
    justify-content: center;
    width: 100%;
}

.hl-security-badge i { color: var(--blue); font-size: 9px; }

/* ══════════════════════════════════════════════════
   RESPONSIVE
══════════════════════════════════════════════════ */
@media (max-width: 900px) {
    body, html { overflow: auto; }

    .hl-shell {
        grid-template-columns: 1fr;
        min-height: 100vh;
    }

    .hl-left {
        padding: 28px 24px;
        border-right: none;
        border-bottom: 1px solid var(--border);
        flex-direction: row;
        align-items: center;
        gap: 20px;
    }

    .hl-panel-wrap,
    .hl-claim-wrap,
    .hl-pillars { display: none; }

    .hl-right {
        padding: 40px 24px;
        align-items: flex-start;
    }

    .hl-form-box { max-width: 100%; }
}

@media (max-width: 480px) {
    .hl-left { padding: 20px 18px; }
    .hl-right { padding: 28px 18px; }
    .hl-form-title { font-size: 23px; }
    .hl-actions { gap: 18px; }
}
</style>
</head>
<body>

<div class="hl-bg"></div>

<%-- Retícula de fondo — evoca datos / trazabilidad de reportes --%>
<div class="hl-topo">
    <svg viewBox="0 0 1440 900" preserveAspectRatio="xMidYMid slice" xmlns="http://www.w3.org/2000/svg">
        <ellipse cx="720" cy="450" rx="680" ry="380" fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <ellipse cx="720" cy="450" rx="560" ry="300" fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <ellipse cx="720" cy="450" rx="440" ry="220" fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <ellipse cx="720" cy="450" rx="320" ry="150" fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <ellipse cx="720" cy="450" rx="200" ry="90"  fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <ellipse cx="720" cy="450" rx="100" ry="45"  fill="none" stroke="#2E9CCA" stroke-width="0.8"/>
        <line x1="0"    y1="450" x2="1440" y2="450" stroke="#2E9CCA" stroke-width="0.4"/>
        <line x1="720"  y1="0"   x2="720"  y2="900" stroke="#2E9CCA" stroke-width="0.4"/>
        <line x1="0"    y1="0"   x2="1440" y2="900" stroke="#2E9CCA" stroke-width="0.3"/>
        <line x1="1440" y1="0"   x2="0"    y2="900" stroke="#2E9CCA" stroke-width="0.3"/>
    </svg>
</div>

<form id="form1" runat="server">

    <div class="hl-shell">

        <!-- ═══════════════════════════════
             PANEL IZQUIERDO — Identidad
        ═══════════════════════════════ -->
        <div class="hl-left">

            <!-- Logotipo -->
            <div class="hl-logo">
                <div class="hl-logo-icon">
                    <img src="../Imagenes/Logo.jpg" alt="Futuro Seguros" />
                </div>
                <div class="hl-logo-text">
                    <div class="hl-logo-name">Utilidades</div>
                    <div class="hl-logo-tagline">Futuro Seguros</div>
                </div>
            </div>

            <!-- Ícono central animado: dashboard de reportería + engranaje de utilidades -->
            <div class="hl-panel-wrap" id="panelWrap">
                <svg class="hl-panel-svg" id="mainPanel"
                     viewBox="0 0 168 168" fill="none" xmlns="http://www.w3.org/2000/svg">

                    <defs>
                        <filter id="panelGlow" x="-30%" y="-30%" width="160%" height="160%">
                            <feGaussianBlur stdDeviation="5" result="blur"/>
                            <feMerge>
                                <feMergeNode in="blur"/>
                                <feMergeNode in="SourceGraphic"/>
                            </feMerge>
                        </filter>
                        <linearGradient id="blueGrad" x1="0%" y1="0%" x2="100%" y2="100%">
                            <stop offset="0%"   stop-color="#6CC5E8"/>
                            <stop offset="50%"  stop-color="#2E9CCA"/>
                            <stop offset="100%" stop-color="#1A6E90"/>
                        </linearGradient>
                        <linearGradient id="panelFill" x1="0%" y1="0%" x2="0%" y2="100%">
                            <stop offset="0%"   stop-color="rgba(46,156,202,0.09)"/>
                            <stop offset="100%" stop-color="rgba(46,156,202,0.02)"/>
                        </linearGradient>
                    </defs>

                    <!-- Fondo del panel -->
                    <rect x="14" y="14" width="140" height="140" rx="18"
                          fill="url(#panelFill)" filter="url(#panelGlow)"/>

                    <!-- Marco del dashboard — se dibuja -->
                    <rect class="pnl-frame"
                          x="14" y="14" width="140" height="140" rx="18"
                          stroke="url(#blueGrad)" stroke-width="2.5" fill="none"/>

                    <!-- Barra superior del dashboard (encabezado) -->
                    <line x1="26" y1="38" x2="142" y2="38" stroke="rgba(46,156,202,0.25)" stroke-width="1" stroke-dasharray="3 4"/>
                    <circle cx="32" cy="26" r="3" fill="rgba(46,156,202,0.45)"/>
                    <circle cx="44" cy="26" r="3" fill="rgba(46,156,202,0.25)"/>

                    <!-- Barras del reporte (crecen desde la base) -->
                    <rect class="pnl-bar pnl-bar1" x="30" y="98" width="14" height="34" rx="3" fill="url(#blueGrad)" opacity="0.55"/>
                    <rect class="pnl-bar pnl-bar2" x="52" y="82" width="14" height="50" rx="3" fill="url(#blueGrad)" opacity="0.7"/>
                    <rect class="pnl-bar pnl-bar3" x="74" y="66" width="14" height="66" rx="3" fill="url(#blueGrad)" opacity="0.85"/>
                    <rect class="pnl-bar pnl-bar4" x="96" y="90" width="14" height="42" rx="3" fill="url(#blueGrad)" opacity="0.7"/>

                    <!-- Línea de tendencia sobre las barras -->
                    <polyline class="pnl-trend"
                        points="30,92 52,74 74,54 96,66 122,44"
                        stroke="url(#blueGrad)" stroke-width="3" stroke-linecap="round" stroke-linejoin="round" fill="none"/>
                    <circle class="pnl-trend-dot" cx="122" cy="44" r="5" fill="#6CC5E8"/>

                    <!-- Engranaje: representa procesos / utilidades -->
                    <g class="pnl-gear" transform="translate(122,116)">
                        <circle r="13" fill="none" stroke="url(#blueGrad)" stroke-width="2"/>
                        <circle r="4.5" fill="url(#blueGrad)"/>
                        <g stroke="url(#blueGrad)" stroke-width="2.4" stroke-linecap="round">
                            <line x1="0" y1="-16.5" x2="0" y2="-12.5"/>
                            <line x1="0" y1="16.5"  x2="0" y2="12.5"/>
                            <line x1="-16.5" y1="0" x2="-12.5" y2="0"/>
                            <line x1="16.5"  y1="0" x2="12.5"  y2="0"/>
                            <line x1="-11.7" y1="-11.7" x2="-8.8" y2="-8.8"/>
                            <line x1="11.7"  y1="11.7"  x2="8.8"  y2="8.8"/>
                            <line x1="-11.7" y1="11.7"  x2="-8.8" y2="8.8"/>
                            <line x1="11.7"  y1="-11.7" x2="8.8"  y2="-8.8"/>
                        </g>
                    </g>
                </svg>

                <!-- Texto rotante debajo del panel -->
                <div class="hl-claim-wrap">
                    <div class="hl-claim-item visible" id="claim0">
                        <div class="hl-claim-word">Eficiencia</div>
                        <div class="hl-claim-sub">En cada proceso operativo</div>
                    </div>
                    <div class="hl-claim-item" id="claim1">
                        <div class="hl-claim-word">Reportería</div>
                        <div class="hl-claim-sub">Datos claros para decidir mejor</div>
                    </div>
                    <div class="hl-claim-item" id="claim2">
                        <div class="hl-claim-word">Control</div>
                        <div class="hl-claim-sub">Sobre cada utilidad del sistema</div>
                    </div>
                </div>
            </div>

            <!-- Pilares en la base -->
            <div class="hl-pillars">
                <div class="hl-pillar">
                    <div class="hl-pillar-num">100%</div>
                    <div class="hl-pillar-label">Trazable</div>
                </div>
                <div class="hl-pillar">
                    <div class="hl-pillar-num">24/7</div>
                    <div class="hl-pillar-label">Disponible</div>
                </div>
                <div class="hl-pillar">
                    <div class="hl-pillar-num">100%</div>
                    <div class="hl-pillar-label">Seguro</div>
                </div>
            </div>

        </div>
        <%-- /hl-left --%>

        <!-- ═══════════════════════════════
             PANEL DERECHO — Formularios
        ═══════════════════════════════ -->
        <div class="hl-right">
            <div class="hl-form-box">

                <!-- ── BLOQUE LOGIN ── -->
                <div id="DivBloqueLogin" runat="server">

                    <div class="hl-form-header">
                        <div class="hl-form-eyebrow">Acceso Seguro</div>
                        <div class="hl-form-title">Bienvenido de&nbsp;vuelta</div>
                        <div class="hl-form-desc">
                            Ingresa tus credenciales para acceder al sistema de utilidades y reportería.
                        </div>
                    </div>

                    <asp:Label ID="lbContador" runat="server" Text="0" Visible="false"></asp:Label>

                    <div class="hl-field">
                        <div class="hl-field-label"><span>Usuario</span></div>
                        <div class="hl-input-wrap">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="hl-input"
                                AutoCompleteType="Disabled" placeholder="Nombre de usuario"></asp:TextBox>
                            <i class="fa fa-user hl-input-icon"></i>
                        </div>
                    </div>

                    <div class="hl-field">
                        <div class="hl-field-label"><span>Contraseña</span></div>
                        <div class="hl-input-wrap">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="hl-input"
                                TextMode="Password" placeholder="Contraseña de acceso"></asp:TextBox>
                            <i class="fa fa-lock hl-input-icon"></i>
                        </div>
                    </div>

                </div>
                <%-- /DivBloqueLogin --%>

                <!-- ── BLOQUE CAMBIO DE CLAVE ── -->
                <div id="DivBloqueCambiaClave" runat="server">

                    <div class="hl-divider-label">Cambio de Contraseña</div>

                    <div class="hl-field">
                        <div class="hl-field-label"><span>Nueva Clave</span></div>
                        <div class="hl-input-wrap">
                            <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="hl-input"
                                TextMode="Password" placeholder="Nueva contraseña"></asp:TextBox>
                            <i class="fa fa-key hl-input-icon"></i>
                        </div>
                    </div>

                    <div class="hl-field">
                        <div class="hl-field-label"><span>Confirmar Clave</span></div>
                        <div class="hl-input-wrap">
                            <asp:TextBox ID="txtConformacionClave" runat="server" CssClass="hl-input"
                                TextMode="Password" placeholder="Confirma la nueva contraseña"></asp:TextBox>
                            <i class="fa fa-check-circle hl-input-icon"></i>
                        </div>
                    </div>

                </div>
                <%-- /DivBloqueCambiaClave --%>

                <div class="hl-divider"></div>

                <!-- Botones con imágenes (se conservan tal cual: ID, OnClick, ImageUrl, ToolTip) -->
                <div class="hl-actions">
                    <div class="hl-action">
                        <div class="hl-action-btn-wrap primario">
                            <asp:ImageButton ID="btnIngresarSistema" runat="server" ToolTip="Ingresar al Sistema"
                                             CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Entrar.png"
                                             OnClick="btnIngresarSistema_Click" />
                        </div>
                        <span class="hl-action-label">Ingresar</span>
                    </div>
                    <div class="hl-action">
                        <div class="hl-action-btn-wrap">
                            <asp:ImageButton ID="btnCambioClave" runat="server" ToolTip="Cambiar Clave"
                                             CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png"
                                             OnClick="btnCambioClave_Click" />
                        </div>
                        <span class="hl-action-label">Cambiar Clave</span>
                    </div>
                </div>

                <div class="hl-form-footer">
                    <div class="hl-security-badge">
                        <i class="fa fa-lock"></i>
                        Conexión protegida · Solo personal autorizado
                    </div>
                </div>

            </div>
        </div>
        <%-- /hl-right --%>

    </div>
    <%-- /hl-shell --%>

</form>

<!-- ══════════════════════════════════════════════════
     JAVASCRIPT — solo efectos visuales
══════════════════════════════════════════════════ -->
<script>
    $(function () {

        /* ── Panel reactivo al focus de los campos ── */
        var $panel = $('#mainPanel');

        $('.hl-input').focus(function () {
            $panel.addClass('active');
        }).blur(function () {
            $panel.removeClass('active');
        });

        /* ── Iconos reactivos al focus del campo ── */
        $('.hl-input-wrap').each(function () {
            var $wrap = $(this);
            $wrap.find('.hl-input').focus(function () {
                $wrap.find('.hl-input-icon').css('color', 'var(--blue)');
            }).blur(function () {
                $wrap.find('.hl-input-icon').css('color', 'var(--text-dim)');
            });
        });

        /* ── Rotación del claim (Eficiencia / Reportería / Control) ── */
        var claims = ['claim0', 'claim1', 'claim2'];
        var current = 0;

        setInterval(function () {
            $('#' + claims[current]).removeClass('visible');
            current = (current + 1) % claims.length;
            $('#' + claims[current]).addClass('visible');
        }, 3200);

    });
</script>

</body>
</html>
