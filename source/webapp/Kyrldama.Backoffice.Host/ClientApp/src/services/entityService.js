import axios from 'axios'

export default class EntityService
{
    constructor()
    {
    }

    async getEntityTemplates()
    {
        let response = await axios.get("api/Entity/Template");
        return response.data;
    }
}