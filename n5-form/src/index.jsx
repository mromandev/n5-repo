import React, { useEffect, useState } from 'react'
import { createRoot }  from 'react-dom/client'
import Form from './components/Form/Form'
import List from './components/List/List'
import { getPermissions, getPermissionTypes, updPermissions, addPermission } from './services/api'
import './styles/styles.scss'

const Crud = () => {
    const [showForm, setShowForm] = useState(false);
    const [rowToEdit, setRowToEdit] = useState(null);
    const [permTypes, setPermTypes] = useState([]);
    const [rows, setRows] = useState([]);

    useEffect(() => {
        if (rows.length === 0 && permTypes.length === 0) {
            Promise.all([
                getPermissions(), 
                getPermissionTypes()
            ]).then(([permissions, permissionTypes]) => {
                setRows([...permissions]);
                setPermTypes([...permissionTypes]);
            });
        }
    }, [rows, permTypes]);

    const configForm = (row, show) => {
        setRowToEdit(row);
        setShowForm(show);
    }

    const save = (row) => {
        const newOrEditedPermission = {
            NombreEmpleado: row.nombreEmpleado,
            ApellidoEmpleado: row.apellidoEmpleado,
            Id: row.id,
            IdTipoPermiso: row.idTipoPermiso
        }

        if (rowToEdit === null) {
            Promise.resolve(addPermission(newOrEditedPermission))
            .then((response) => {
                setRows([response, ...rows]);
                configForm(null, false);
            });

        setRowToEdit(null);
        } else {
            Promise.resolve(updPermissions(newOrEditedPermission))
                .then((response) => {
                    let newRows = rows.map(el => (el.id === response.id ? response : el));
                    setRows(newRows);
                    configForm(null, false);
                });

            setRowToEdit(null);
        }        
    }

    return (
        <div>
            <div className="header">
                <img src={require("./img/n5.png")} alt="logo" />
            </div>
            <div className="container root-container">
                <List 
                    rows={rows} 
                    permTypes={permTypes}
                    onSetEdit={(row) => configForm(row, true)} 
                    onPressNew={() => configForm(null, true)} />

                { showForm ? <Form 
                                permTypes={permTypes}
                                rowToEdit={rowToEdit} 
                                onCancel={() => configForm(null, false)} 
                                onSave={(row) => save(row)} /> : '' }
            </div>
        </div>
    )
}

const root = createRoot(document.getElementById('root'));
root.render(<Crud />);