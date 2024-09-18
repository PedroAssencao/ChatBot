import React, { useEffect, useRef } from "react";
import "./style.css";
import Chart from "chart.js/auto"; // Certifique-se de que você tem o Chart.js instalado

export default function Mensagem() {
  const chartRef = useRef(null); // Ref para armazenar a instância do gráfico

  useEffect(() => {
    if (window.Chart) {
      const canvas = document.getElementById("Departamento");
      const ctx = canvas.getContext("2d");

      // Se já houver um gráfico, destrua-o
      if (chartRef.current) {
        chartRef.current.destroy();
      }

      // Crie um novo gráfico e armazene a instância na ref
      chartRef.current = new Chart(ctx, {
        type: "pie",
        data: {
          datasets: [
            {
              label: "# of Votes",
              data: [19, 12],
              borderWidth: 1,
              backgroundColor: ["purple", "rgba(128, 0, 128, 0.582)"],
            },
          ],
        },
        options: {
          plugins: {
            legend: {
              display: false, // Oculta a legenda
            },
          },
        },
      });
    }

    // Limpeza ao desmontar o componente
    return () => {
      if (chartRef.current) {
        chartRef.current.destroy();
      }
    };
  }, []); // O array vazio garante que o efeito só será executado na montagem inicial

  return (
    <div className="card Departamento">
      <div className="DepartamentoHeader">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="16"
          height="16"
          fill="#263a6d"
          className="bi bi-info-circle"
          viewBox="0 0 16 16"
        >
          <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
          <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
        </svg>
      </div>

      <div className="DepartamentoInfo">
        <p className="DepartamentoTitle">Departamentos</p>
        <select class="form-select form-select mb-3 DepartamentoBtn" aria-label="Large select example">
          <option selected>Atendimentos Pendentes</option>
          <option value="1">Atendimentos Ativos</option>
        </select>


      </div>

      <div className="Container">
        <div className="DepartamentoGrafico">
          <canvas id="Departamento"></canvas>
        </div>
      </div>
    </div>
  );
}
