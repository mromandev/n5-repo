import React, { useEffect, useState } from 'react'
import PropTypes from 'prop-types'

const initForm = {
    nombreEmpleado: "",
    apellidoEmpleado: "",
    idTipoPermiso: 0,
    id: 0
}

const Form = ({ permTypes, rowToEdit, onCancel, onSave }) => {
    const [form, setForm] = useState(initForm);

    useEffect(() => {
        setForm(rowToEdit ? rowToEdit : initForm);
    }, [rowToEdit])

    const renderOptions = (el) => {
        return <option key={el.id} value={el.id}>{el.descripcion}</option>
    }

    const handleSubmit = (ev) => {
        ev.preventDefault();

        if (!form.nombreEmpleado || !form.apellidoEmpleado || form.idTipoPermiso === 0) {
            alert("Verificar los datos a ingresar.");
            return;
        }

        onSave(form);
    }

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    }

    return (<form onSubmit={e => handleSubmit(e)}>
        <div>
            <h2 className='title'>{form.id ? `Editar permisos` : `Agregar permisos`}</h2>
            <div className="row">
                <div className="col">
                    <label htmlFor="nombreEmpleado">Nombre</label>
                    <input
                        type="text"
                        value={form.nombreEmpleado}
                        onChange={handleChange}
                        className='form-control'
                        name="nombreEmpleado"
                        id="name" />
                </div>
                <div className="col">
                    <label htmlFor="apellidoEmpleado">Apellido</label>
                    <input
                        type="text"
                        value={form.apellidoEmpleado}
                        onChange={handleChange}
                        className='form-control'
                        name="apellidoEmpleado"
                        id="surname" />
                </div>
                <div className="col">
                    <label htmlFor="idTipoPermiso">Permisos</label>
                    <select
                        name="idTipoPermiso"
                        value={form.idTipoPermiso}
                        onChange={handleChange}
                        id="ptype"
                        className="form-select">
                        <option value="0">Seleccione un nivel de permisos</option>
                        {
                            permTypes.map(p => renderOptions(p))
                        }
                    </select>
                </div>
            </div>
            <div className="row form__buttons">
                <button
                    type="button"
                    className='btn btn-normal'
                    onClick={() => onCancel()}>Cancelar</button>
                <button type="submit" className='btn btn-success'>Guardar</button>
            </div>
        </div>
    </form>)
}

Form.propTypes = {
    permTypes: PropTypes.array.isRequired,
    rowToEdit: PropTypes.shape({
        nombreEmpleado: PropTypes.string.isRequired,
        apellidoEmpleado: PropTypes.string.isRequired,
        id: PropTypes.number.isRequired,
        idTipoPermiso: PropTypes.number.isRequired
    }),
    onCancel: PropTypes.func.isRequired,
    onSave: PropTypes.func.isRequired
}

export default Form