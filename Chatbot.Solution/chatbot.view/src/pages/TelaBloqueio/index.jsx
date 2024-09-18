import React, { useState } from 'react';
import './style.css';

export default function TelaBloqueio() {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [newContact, setNewContact] = useState('');
    const [selectedBot, setSelectedBot] = useState('');
    const [contacts, setContacts] = useState([
        { number: '7999923879', bot: 'DazzleBot' },
        { number: '799938392', bot: 'DazzleBot' },
    ]);

    document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;";

    const handleAddContact = () => {
        if (newContact && selectedBot) {
            const updatedContacts = [...contacts, { number: newContact, bot: selectedBot }];
            setContacts(updatedContacts);
            setNewContact('');
            setSelectedBot('');
            setIsModalOpen(false);
        } else {
            alert("Por favor, preencha todos os campos.");
        }
    };

    return (
        <div className="col">
            <div className="barra-superior">
                <h1>ChatBot</h1>
            </div>

            <div className="conteudo">
                <div className="parte-superior">
                    <h2>Bloqueados</h2>
                    <button type="button" className="btn btn-success" onClick={() => setIsModalOpen(true)}>
                        Adicionar Contato
                    </button>
                </div>

                <hr className="linha-horizontal" />

                <table className="table">
                    <thead className="table-success">
                        <tr>
                            <th scope="col">Contato</th>
                            <th scope="col">Bot</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody className="table-group">
                        {contacts.map((contact, index) => (
                            <tr key={index}>
                                <td>{contact.number}</td>
                                <td>{contact.bot}</td>
                                <td>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                        <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0" />
                                    </svg>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            {isModalOpen && (
               
                    <div class="modal" tabindex="-1">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title">Adicionar Contato</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={() => setIsModalOpen(false)}></button>
                          </div>
                          <div class="modal-body">
                          <label>
                            Bot:
                            <select class="form-select" aria-label="Default select example" value={selectedBot} onChange={(e) => setSelectedBot(e.target.value)}>
                              <option value="">Selecione um bot</option>
                                <option value="DazzleBot">DazzleBot</option>
                            </select>
                        </label>
                        <br />
                        <label>
                            Contato:
                            <div class="input-group mb-3">
                             
                              <input type="text" value={newContact} onChange={(e) => setNewContact(e.target.value)} class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"/>
                            </div>
                           
                        </label>
                        <br />
                          </div>
                          <div class="modal-footer">
                          <button type="button" class="btn btn-primary" onClick={handleAddContact}s>Salvar</button>
                            
                            {/* <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                             */}
                          </div>
                        </div>
                      </div>
                    </div>
            
                        
          
            )}
        </div>
    );
}
