import React, { useEffect } from 'react';
import './style.css';

export default function Ativo() {
    useEffect(() => {
        // Verifique se o Chart.js foi carregado
        if (window.Chart) {
            const ctx = document.getElementById('myChart');

            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Jessica', 'Wesnia', 'Davi', 'Vanessa', 'Luana', 'André', 'Hyago', 'Bruna', 'Isadora'],
                    datasets: [{
                        label: '# of Votes',
                        data: [12, 19, 3, 5, 2, 3, 2, 5, 7],
                        borderWidth: 1,
                        backgroundColor: [
                            'rgba(75, 192, 192, 0.2)',
                        ],
                    }],
    
                },
                options: {
                    plugins: {
                        legend: {
                            display: false // Hides the legend
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    
        // Limpeza ao desmontar o componente
        return () => {
          const canvas = document.getElementById('myChart');
          if (canvas && canvas.chart) {
            canvas.chart.destroy();
          }
        };
      }, []); // O array vazio garante que o efeito só será executado na montagem inicial
    
      return (
        <div className='Ativo'>
        <div className="atendimentoAtivos card">
               <div className='Header'>
                   <p className='title'>Atendimento ativos por atendentes</p>
                   <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="green" className="bi bi-info-circle"
                       viewBox="0 0 16 16">
                       <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                       <path
                           d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
                   </svg>
               </div>
               <hr></hr>
       
               <div>
                   <canvas id="myChart"></canvas>
               </div>
               <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
           </div>
       </div>
      );
}

