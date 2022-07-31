import React from 'react'
import PropTypes from 'prop-types'
import moment from 'moment'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEdit, faAdd } from '@fortawesome/free-solid-svg-icons'

const List = ({rows, permTypes, onSetEdit, onPressNew}) => {

    const renderRow = (el) => {
        const ptype = permTypes.filter(x => x.id == el.idTipoPermiso)[0].descripcion;
        const employee = `${el.apellidoEmpleado}, ${el.nombreEmpleado}`;
        const pdate = moment(el.fechaPermiso).format('DD/MM/YY h:mm');

        return (<tr key={el.id}>
                    <td>{employee}</td>
                    <td>{ptype}</td>
                    <td>{pdate}</td>
                    <td>
                        <div className='actions'>
                        
                            <button 
                                type='button' 
                                className='btn btn-primary' 
                                onClick={() => onSetEdit(el)}>
                                    <FontAwesomeIcon icon={faEdit} />
                            </button>
                        </div>
                    </td>
                </tr>)
    }

    return (
        <div className="row">
            <div className="title-bar">
                <h1 className='title'>Lista de permisos</h1>
                <button 
                    type='button' 
                    className='btn btn-success' 
                    onClick={() => onPressNew()}>
                        <FontAwesomeIcon icon={faAdd} />
                    </button>
            </div>

            <table className='table'>
                <thead>
                    <tr>
                        <th>Empleado</th>
                        <th>Permiso</th>
                        <th>Fecha permiso</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        rows.length === 0 ? 
                        <tr>
                            <td colSpan="3">No se han encontrado permisos asignados.</td>
                        </tr> : 
                        rows.map(row => renderRow(row))
                    }                    
                </tbody>
            </table>
        </div>
    )
}

List.propTypes = {
    rows: PropTypes.array.isRequired,
    permTypes: PropTypes.array.isRequired,
    onSetEdit: PropTypes.func.isRequired,
    onPressNew: PropTypes.func.isRequired
}

export default List