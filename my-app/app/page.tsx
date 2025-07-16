"use client";

import Image from "next/image";
import styles from "./page.module.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faBars,
  faUserGraduate,
  faBuilding,
  faBookOpen,
} from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

import StudentsPage from "./components/students/page";
import DepartmentsPage from "./components/Departments/Page";
import SubjectsPage from "./components/Subjects/page";

export default function Home() {
  const [isCollapsed, setIsCollapsed] = useState(false);
  const [activePage, setActivePage] = useState("students");
  return (
    <div className={styles.page}>
      <nav
        className={styles.navigation}
        style={{
          width: isCollapsed ? "50px" : "200px",
          transition: "0.3s",
        }}
      >
        <button
          className={styles.collapse}
          onClick={() => setIsCollapsed(!isCollapsed)}
        >
          <FontAwesomeIcon icon={faBars} />
        </button>
        <ul>
          <li>
            <button
              className={styles.btn}
              onClick={() => setActivePage("students")}
              style={{
                color:
                  activePage === "students"
                    ? "rgba(245, 222, 179, 0.77)"
                    : "darkgrey",
                textAlign: isCollapsed ? "center" : "start",
              }}
            >
              {isCollapsed ? (
                <FontAwesomeIcon icon={faUserGraduate} />
              ) : (
                "Students"
              )}
            </button>
          </li>
          <li>
            <button
              className={styles.btn}
              onClick={() => setActivePage("departments")}
              style={{
                color:
                  activePage === "departments"
                    ? "rgba(245, 222, 179, 0.77)"
                    : "darkgrey",
                textAlign: isCollapsed ? "center" : "start",
              }}
            >
              {isCollapsed ? (
                <FontAwesomeIcon icon={faBuilding} />
              ) : (
                "departments"
              )}
            </button>
          </li>
          <li>
            <button
              className={styles.btn}
              onClick={() => setActivePage("subjects")}
              style={{
                color:
                  activePage === "subjects"
                    ? "rgba(245, 222, 179, 0.77)"
                    : "darkgrey",
                textAlign: isCollapsed ? "center" : "start",
              }}
            >
              {isCollapsed ? <FontAwesomeIcon icon={faBookOpen} /> : "Subjects"}
            </button>
          </li>
        </ul>
      </nav>
      <main className={styles.main}>
        {activePage === "students" && <StudentsPage />}
        {activePage === "departments" && <DepartmentsPage />}
        {activePage === "subjects" && <SubjectsPage />}
      </main>
    </div>
  );
}
