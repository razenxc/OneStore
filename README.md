# OneStore

# API Endpoints: Category Management

## **Category**

### **Get All Categories**  
**Method:** `[GET] /api/category`  
**Response:**  
```json
[
  {
    "id": int,
    "name": string
  }
]
```

---

### **Get Category by ID**  
**Method:** `[GET] /api/category/{id}`  
**Response:**  
```json
{
  "id": int,
  "name": string
}
```

---

### **Create Category**  
**Method:** `[POST] /api/category`  
**Request Body:**  
```json
{
  "name": string
}
```  
**Response:**  
```json
{
  "id": int,
  "name": string
}
```

---

### **Update Category**  
**Method:** `[PUT] /api/category/{id}`  
**Request Body:**  
```json
{
  "name": string
}
```  
**Response:**  
```json
{
  "id": int,
  "name": string
}
```

---

### **Delete Category**  
**Method:** `[DELETE] /api/category/{id}`  
**Response:**  
`204 No Content`