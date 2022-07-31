import axios from 'axios'

const API_PERMISOS = "https://localhost:7177/api/Permisos"
const API_TIPOS = "https://localhost:7177/api/TiposPermisos"
const DEF_HEADERS = {
    accept: "application/json"
}

export const getPermissions = id => {
    const endpoint = id ? `${API_PERMISOS}/${id}` : API_PERMISOS;
    return axios.get(endpoint)
        .then(response => {
            const { data } = response;
            return data;
        }).catch(err => alert(err));
}

export const updPermissions = permission => {
    return axios.put(API_PERMISOS, permission, DEF_HEADERS)
        .then(response => {
            const { data } = response;
            return data;
        }).catch(err => alert(err));
} 

export const addPermission = permission => {
    return axios.post(API_PERMISOS, permission, DEF_HEADERS)
        .then(response => {
            const { data } = response;
            return data;
        }).catch(err => alert(err));
}

export const getPermissionTypes = () => {
    return axios.get(API_TIPOS)
        .then(response => {
            const { data } = response;
            return data;
        }).catch(err => alert(err));
}