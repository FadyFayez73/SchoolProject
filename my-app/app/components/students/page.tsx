"use client";

import { useEffect, useState } from "react";
import styles from "./page.module.css";
import { UUID } from "crypto";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faEdit } from "@fortawesome/free-solid-svg-icons";

type student = {
  studID: UUID;
  name: string;
  address: string;
  phone: string;
};

function Students() {
  const [students, setStudents] = useState<student[] | null>(null);

  useEffect(() => {
    fetch("/api/students")
      .then((res) => res.json())
      .then((data) => setStudents(data))
      .catch((err) => console.error("Error from students page:", err));
  }, []);

  const DeleteStudent = (studid: UUID) => {
    fetch(`/api/students/${studid}`, {
      method: "PUT",
    }).catch((err) => console.error("Error from students page:", err));
  };

  return (
    <div className={styles.page}>
      <div className={styles.collection}>
        <table className={styles.table}>
          <thead>
            <tr>
              <th>StudId</th>
              <th>Name</th>
              <th>Address</th>
              <th>Phone</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {students?.map((student) => (
              <tr key={student.studID}>
                <td>{student.studID}</td>
                <td>{student.name}</td>
                <td>{student.address}</td>
                <td>{student.phone}</td>
                <td>
                  <div className={styles.tableActions}>
                    <button className={styles.actionBtn}>
                      <FontAwesomeIcon icon={faEdit} />
                    </button>
                    <button className={styles.actionBtn}>
                      <FontAwesomeIcon icon={faTrash} />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default Students;
